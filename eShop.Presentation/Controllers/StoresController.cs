using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using SharedAPI.Data_Transfer;
using SharedAPI.Request_Features;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoresController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public StoresController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetStores([FromQuery] StoreParameters parameters)
        {
           if(parameters.orderBy is null)
            {
                parameters.orderBy = "";
            }
            if (parameters.searchTerm is null)
            {
                parameters.searchTerm = "";
            }
            var username = HttpContext.User.Identity.Name;
            var response = await serviceManager.stores.GetStores(parameters, username, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.metadata));

            return Ok(response.stores);
        }

        [HttpGet("{Id:guid}", Name = "StoreByID")]
        public async Task<IActionResult> GetStoreById(Guid Id)
        {
            try
            {
                var username = HttpContext?.User?.Identity?.Name;

                var response = await serviceManager.stores.GetStoreById(Id, username, trackChanges: false);

                return Ok(response);

            }catch(StoreNotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Error = ex.Message
                });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDto storeDto)
        {
            if(storeDto == null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Store Creation Object Can Not Be Null"
                });
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var username = HttpContext?.User?.Identity?.Name;

            try
            {
                var response = await serviceManager.stores.CreateStore(username, storeDto);
                return CreatedAtRoute("StoreByID", new { Id = response.Id }, response);
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 404,
                    Error = ex.Message
                });
            }

            
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteStore(Guid Id)
        {
            try
            {
                if (Id.Equals(null))
                {
                    return UnprocessableEntity(ModelState);
                }

                var username = HttpContext?.User?.Identity?.Name;
                
                await serviceManager.stores.DeleteStore(username, Id);

                return NoContent();

            }catch(NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Error = ex.Message
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
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> UpdateStore(Guid Id, [FromBody]StoreUpdateDto updateModel)
        {
            try
            {
                if(updateModel is null)
                {
                    return BadRequest(
                        new
                        {
                            StatusCode = 400,
                            Message = "Store Update Model Can Not Be Null"
                        }
                        );
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                var username = HttpContext?.User?.Identity?.Name;

                await serviceManager.stores.UpdateStore(Id, username, updateModel, trackChanges: true);

                return NoContent();
            }catch(NotFoundException ex)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Error = ex.Message
                });
            }
        }
    }
}
