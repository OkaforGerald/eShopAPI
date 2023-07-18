using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/Stores/{StoreID}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(IServiceManager serviceManager, IWebHostEnvironment webHostEnvironment)
        {
            this.serviceManager = serviceManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(Guid StoreID, [FromQuery] ProductParameters parameters)
        {
            try
            {
                var result = await serviceManager.products.GetProducts(StoreID, parameters, trackChanges: false);

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
        public async Task<IActionResult> ProductsById(Guid StoreID, Guid Id)
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateProduct(Guid StoreID, [FromForm] ProductCreationDto product)
        {
            if(product is null)
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

            string imageUrl = await GetImageUrlAsync(StoreID, product.Image);

            var response = await serviceManager.products.CreateProduct(StoreID, imageUrl, product);

            return CreatedAtRoute("ProductById", new { StoreID, Id = response.Id }, response);
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
