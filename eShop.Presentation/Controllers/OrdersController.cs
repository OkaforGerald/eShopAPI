using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Org.BouncyCastle.Security;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using SharedAPI.Data_Transfer;
using Document = iText.Layout.Document;
using iText.Kernel.Pdf.Canvas.Draw;
using System.Globalization;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
            private readonly IServiceManager serviceManager;

            public OrdersController(IServiceManager serviceManager)
            {
                this.serviceManager = serviceManager;
            }

            [HttpGet]
            [Authorize]
            public async Task<IActionResult> GetOrders()
            {
                var username = HttpContext?.User?.Identity?.Name;

                var orders = await serviceManager.cart.GetUserOrdersAsync(username);

                return Ok(orders);
            }
        /// <summary>
        /// Generate invoice for a report
        /// </summary>
        /// <returns>Downloads an invoice</returns>
        [HttpGet("{Id:Guid}/invoice/{username}")]
        public async Task<IActionResult> DownloadInvoice(Guid Id, string username)
        {
            var order = await serviceManager.cart.GetUserOrderById(username, Id);

            if(order != null)
            {
                string[] orderItems = order.OrderSummary.Split(new string[] { ", " }, StringSplitOptions.None);

                
                List<(string productName, int quantity, decimal price)> productList = new List<(string, int, decimal)>();
                //SecurityHandlerInitializer.Initialize(provider);

                foreach (string item in orderItems)
                {
                    // Split each item by "x" to separate product name and quantity
                    string[] parts = item.Split(new string[] { " x " }, StringSplitOptions.None);

                    if (parts.Length == 3)
                    {
                        string productName = parts[0].Trim();
                        int quantity = int.Parse(parts[1].Trim());
                        decimal price = decimal.Parse(parts[2].Trim());
                        productList.Add((productName, quantity, price));
                    }
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    PdfWriter writer = new PdfWriter(ms);
                    PdfDocument pdfDoc = new PdfDocument(writer);
                    Document document = new iText.Layout.Document(pdfDoc);

                    Paragraph header = new Paragraph("ORDER INVOICE").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
                    document.Add(header);

                    Paragraph subheader = new Paragraph($"AUTOMATICALLY GENERATED INVOICE ISSUED BY {order.SellerName.ToUpper()}").SetTextAlignment(TextAlignment.CENTER).SetFontSize(10);
                    document.Add(subheader);

                    LineSeparator ls = new LineSeparator(new SolidLine());
                    document.Add(ls);

                    Paragraph sellerHeader = new Paragraph("Sold by:").SetBold().SetTextAlignment(TextAlignment.LEFT);
                    Paragraph sellerDetail = new Paragraph(order.SellerName).SetTextAlignment(TextAlignment.LEFT);
                    Paragraph sellerAddress = new Paragraph(order.SellerLocation).SetTextAlignment(TextAlignment.LEFT);
                    Paragraph sellerContact = new Paragraph(order.SellerPhone).SetTextAlignment(TextAlignment.LEFT);

                    document.Add(sellerHeader);
                    document.Add(sellerDetail);
                    document.Add(sellerAddress);
                    document.Add(sellerContact);

                    Paragraph customerHeader = new Paragraph("Customer details:").SetBold().SetTextAlignment(TextAlignment.RIGHT);
                    Paragraph customerDetail = new Paragraph(order.Buyer).SetTextAlignment(TextAlignment.RIGHT);
                    Paragraph customerAddress1 = new Paragraph("Babcock University").SetTextAlignment(TextAlignment.RIGHT);
                    Paragraph customerAddress2 = new Paragraph("Ilishan-Remo").SetTextAlignment(TextAlignment.RIGHT);

                    Paragraph customerContact = new Paragraph(order.BuyerNumber).SetTextAlignment(TextAlignment.RIGHT);

                    document.Add(customerHeader);
                    document.Add(customerDetail);
                    document.Add(customerAddress1);
                    document.Add(customerAddress2);
                    document.Add(customerContact);

                    Paragraph orderNo = new Paragraph($"Order No:{order.Id}").SetBold().SetTextAlignment(TextAlignment.LEFT);
                    Paragraph invoiceNo = new Paragraph("Invoice No:MH-MU-1077").SetTextAlignment(TextAlignment.LEFT);
                    Paragraph invoiceTimestamp = new Paragraph(order.OrderDate.ToLongDateString()).SetTextAlignment(TextAlignment.LEFT);

                    document.Add(orderNo);
                    document.Add(invoiceNo);
                    document.Add(invoiceTimestamp);

                    Table table = new Table(5, true);

                    table.SetFontSize(9);
                    Cell headerProductId = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Code"));
                    Cell headerProduct = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Product"));
                    Cell headerProductPrice = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Price"));
                    Cell headerProductQty = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Qty"));
                    Cell headerTotal = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph("Total"));

                    table.AddCell(headerProductId);
                    table.AddCell(headerProduct);
                    table.AddCell(headerProductPrice);
                    table.AddCell(headerProductQty);
                    table.AddCell(headerTotal);

                    foreach (var c in productList)
                    {
                        Cell productid = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(order.Id.ToString()));
                        Cell product = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.productName));
                        Cell price = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.price.ToString()));
                        Cell qty = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(c.quantity.ToString()));
                        var value = c.price * c.quantity;
                        Cell total = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(value.ToString()));

                        table.AddCell(productid);
                        table.AddCell(product);
                        table.AddCell(price);
                        table.AddCell(qty);
                        table.AddCell(total);
                    }

                    Cell grandTotalHeader = new Cell(1, 4).SetTextAlignment(TextAlignment.RIGHT).Add(new Paragraph("Total: "));
                    Cell grandTotal = new Cell(1, 1).SetTextAlignment(TextAlignment.LEFT).Add(new Paragraph(" " + order.Price.ToString("C", new CultureInfo("HA-LATN-NG"))));

                    table.AddCell(grandTotalHeader);
                    table.AddCell(grandTotal);

                    document.Add(table);
                    table.Flush();
                    table.Complete();
                    document.Close();
                    // Create a HttpResponseMessage with the PDF file
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(ms.ToArray());
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = "invoice.pdf";
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

                    return File(ms.ToArray(), "application/pdf", "invoice.pdf");
                }
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NoContent);
                return null;
            }
        }

        [NonAction]
        public Document GenerateInvoice(OrderProductDto order)
        {
            PdfWriter writer = new PdfWriter("invoice.pdf");
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document document = new Document(pdfDoc);

            // Add company information
            document.Add(new Paragraph("Company Name"));
            document.Add(new Paragraph("[Street Address]"));
            document.Add(new Paragraph("[City, ST ZIP]"));
            document.Add(new Paragraph("Phone: [000-000-0000]"));
            document.Add(new Paragraph("Fax: [000-000-0000]"));
            document.Add(new Paragraph("Website: some@domain.com"));

            // Add invoice header
            document.Add(new Paragraph("INVOICE"));
            document.Add(new Paragraph($"DATE\t12/9/2019\nINVOICE\t[123456]\nCUSTOMER ID\t[123]\nDUE DATE\t1/8/2020"));

            // Add bill to section
            document.Add(new Paragraph("BILL TO"));
            document.Add(new Paragraph("[Name]"));
            document.Add(new Paragraph("[Company Name]"));
            document.Add(new Paragraph("[Street Address]"));
            document.Add(new Paragraph("[City, ST ZIP]"));
            document.Add(new Paragraph("[Phone]"));

            // Create a table for invoice items
            Table table = new Table(UnitValue.CreatePercentArray(new float[] { 3, 1, 1 }));
            table.AddHeaderCell("DESCRIPTION");
            table.AddHeaderCell("TAXED");
            table.AddHeaderCell("AMOUNT");
            table.AddCell("Service Fee");
            table.AddCell("");
            table.AddCell("230.00");
            table.AddCell("Labor 5 hours at $75/hr");
            table.AddCell("X");
            table.AddCell("375.00");
            table.AddCell("[Parts]");
            table.AddCell("");
            table.AddCell("345.00");

            // Add the table to the document
            document.Add(table);

            // Add subtotal, tax, and total
            document.Add(new Paragraph($"Subtotal\t950.00\nTaxable\t345.00\nTax rate\t6.25%\nTax due\t21.56\nOther\t-\nTOTAL\t$\t971.56"));

            // Add other comments
            document.Add(new Paragraph("OTHER COMMENTS"));
            document.Add(new Paragraph("1. Total payment due in 30 days"));
            document.Add(new Paragraph("2. Please include the invoice number on your check"));
            document.Add(new Paragraph($"Make all checks payable to\n[Your Company Name]"));

            // Add contact information
            document.Add(new Paragraph($"If you have any questions about this invoice, please contact\n[Name, Phone #, E-mail]"));
            document.Add(new Paragraph("Thank You For Your Business!"));

            // Close the document
            document.Close();

            return document;
        }
    }
}
