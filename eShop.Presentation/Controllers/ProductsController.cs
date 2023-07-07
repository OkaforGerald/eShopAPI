using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Request_Features;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/Stores/{StoreID}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
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

        [HttpGet("{Id}")]
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
    }
}
