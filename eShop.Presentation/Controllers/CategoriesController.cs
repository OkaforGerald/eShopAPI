using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Data_Transfer;
using Shared.Request_Features;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public CategoriesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await serviceManager.category.GetCategories(trackChanges: false);

            return Ok(categories);
        }

        [HttpGet("{Id:Guid}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            try
            {
                var category = await serviceManager.category.GetCategoryById(Id, trackChanges: false);

                return Ok(category);

            }
            catch (NotFoundException e)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = e.Message
                });
            }
        }

        [HttpPut("{Id:Guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateCategory(Guid Id, [FromBody] CreateCategoryDto model)
        {
            if (model is null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Category Update Object Can Not Be Null"
                });
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await serviceManager.category.UpdateCategory(Id, model);
            return NoContent();
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            try
            {
                await serviceManager.category.DeleteCategory(Id);

                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = e.Message
                });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (categoryDto is null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Category Creation Object Can Not Be Null"
                });
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var category = await serviceManager.category.CreateCategory(categoryDto);

            return CreatedAtRoute("CategoryById", new { Id = category.Id }, category);
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProductsByCategory(Guid CategoryId, [FromQuery] ProductParameters parameters)
        {
            try
            {
                var result = await serviceManager.category.GetProducts(CategoryId, parameters, trackChanges: false);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metadata));

                return Ok(result.products);
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
    }
}
