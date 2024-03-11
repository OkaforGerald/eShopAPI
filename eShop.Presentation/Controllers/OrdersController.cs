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

        [HttpGet("{Id:Guid}/invoice")]
        [Authorize]
        public async Task<IActionResult> DownloadInvoice(Guid Id)
        {
            var username = HttpContext?.User?.Identity?.Name;

            var order = await serviceManager.cart.GetUserOrderById(username, Id);

            if(order != null)
            {
                //SecurityHandlerInitializer.Initialize(provider);

                using (MemoryStream ms = new MemoryStream())
                {
                    ;
                    PdfWriter writer = new PdfWriter(ms);
                    PdfDocument pdfDoc = new PdfDocument(writer);
                    Document document = new iText.Layout.Document(pdfDoc);

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
                    //ms.Position = 0;
                    //ms.Seek(0, SeekOrigin.Begin);

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
