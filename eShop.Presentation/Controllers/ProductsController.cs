﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EmailSender;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/Stores/{StoreID}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IEmailSender sender;

        public ProductsController(IServiceManager serviceManager, IWebHostEnvironment webHostEnvironment, IEmailSender sender)
        {
            this.serviceManager = serviceManager;
            this.webHostEnvironment = webHostEnvironment;
            this.sender = sender;   
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts(Guid StoreID, [FromQuery] ProductParameters parameters)
        {
            if (parameters.orderBy is null)
            {
                parameters.orderBy = "";
            }
            if (parameters.searchTerm is null)
            {
                parameters.searchTerm = "";
            }
            try
            {
                var username = HttpContext.User.Identity.Name;
                var result = await serviceManager.products.GetProducts(StoreID, username, parameters, trackChanges: false);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metadata));

                return Ok(result.products);

            }catch (NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{Id}", Name = "ProductById")]
        public async Task<IActionResult> ProductById(Guid StoreID, Guid Id)
        {
            try
            {
                var result = await serviceManager.products.GetProductById(StoreID, Id, trackChanges: false);

                return Ok(result);

            }catch(NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(Guid StoreID, [FromBody] ProductModifyingDto product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Product Creation Object Can Not Be Null"
                    });
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                var username = HttpContext?.User?.Identity?.Name;

                //string imageUrl = await GetImageUrlAsync(StoreID, product.Image);

                var response = await serviceManager.products.CreateProduct(StoreID, username, product.ImageUrl, product);

                return CreatedAtRoute("ProductById", new { StoreID, Id = response.Id }, response);
            }
            catch(Exception ex)
            {
                return Unauthorized(new
                {
                    StatusCode = 401,
                    Error = ex.Message
                });
            }
        }

        [HttpPost("{Id:Guid}/cart")]
        [Authorize]
        public async Task<IActionResult> AddProductToCart(Guid StoreID, Guid Id)
        {
            try
            {
                var username = HttpContext?.User?.Identity?.Name;

                await serviceManager.cart.AddToCart(StoreID, Id, username);

                return NoContent();
            }catch(NotFoundException e)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = e.Message,
                });
            }
        }

        [HttpGet("{Id:Guid}/order/whatsapp")]
        public async Task<IActionResult> CheckoutProduct(Guid StoreID, Guid Id)
        {
            try
            {
                var message = await serviceManager.products.GenerateWhatsappText(StoreID, Id);

                var link = Request.Scheme + "://" + Request.Host + Url.Action("ProductById", "Products", new { StoreID, Id = Id });
                string text = message.text.Replace("ProdLink", link);

                var uri = new Uri("https://api.whatsapp.com/send/?phone=" + message.recipient + "&text=" + text + "&type=phone_number");
                return Redirect(uri.AbsoluteUri);

            }catch(NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{Id:Guid}/order/email")]
        public async Task<IActionResult> CheckoutProductMail(Guid StoreID, Guid Id, string customer)
        {
            try
            {
                var message = await serviceManager.products.GenerateEmailText(StoreID, Id);

                var link = Request.Scheme + "://" + Request.Host + Url.Action("ProductById", "Products", new { StoreID, Id = Id });

                var mail = new Message(new string[] { message.recipient }, "Order Notification", link, message.products, customer);
                var userMail = new Message(new string[] { customer }, "Order Notification", null, message.products, customer);

                var storeMessage = sender.CreateEmailMessage(mail);
                var userMessage = sender.CreateEmailMessage(userMail);
                await sender.SendAsync(new List<MimeKit.MimeMessage>()
                {
                    storeMessage, userMessage
                });

                return NoContent();


            }
            catch (NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(Guid StoreID, Guid Id)
        {
            try
            {
                var username = HttpContext?.User?.Identity?.Name;

                await serviceManager.products.DeleteProducts(StoreID, Id, username, false);

                return NoContent();
            }catch(NotFoundException e)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = e.Message,
                });
            }catch(Exception ex)
            {
                return Unauthorized(new
                {
                    StatusCode = 401,
                    Error = ex.Message
                });
            }
        }

        [HttpPut("{Id:Guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(Guid StoreID, Guid Id, [FromForm] ProductModifyingDto productModifyingDto)
        {
            try
            {
                //string imageUrl = await GetImageUrlAsync(StoreID, productModifyingDto.I);

                var username = HttpContext?.User?.Identity?.Name;

                await serviceManager.products.UpdateProduct(StoreID, Id, username, productModifyingDto.ImageUrl, productModifyingDto);

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = e.Message,
                });
            }catch(Exception ex){
                return Unauthorized(new
                {
                    StatusCode = 401,
                    Error = ex.Message
                });
            }
        }

        [NonAction]
        public async Task<string> GetImageUrlAsync(Guid StoreID, IFormFile file)
        {
            string ImageUrl = string.Empty;

            string filepath = webHostEnvironment.WebRootPath + "\\Images\\" + StoreID;

            if(!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string ImagePath = filepath + "\\" + file.FileName;
            if(System.IO.File.Exists(ImagePath))
            {
                System.IO.File.Delete(ImagePath);
            }

            using(FileStream stream = System.IO.File.Create(ImagePath))
            {
                await file.CopyToAsync(stream);
            }

            ImageUrl = Request.Scheme + "://" + Request.Host + "/Images/" + StoreID + "/" + file.FileName;

            return ImageUrl;
        }
    }
}
