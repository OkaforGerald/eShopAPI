using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Data_Transfer;

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
        public async Task<IActionResult> GetStores()
        {
            var response = await serviceManager.stores.GetStores(trackChanges: false);

            return Ok(response);
        }

        [HttpGet("{Id:guid}", Name = "StoreByID")]
        public async Task<IActionResult> GetStoreById(Guid Id)
        {
            try
            {
                var response = await serviceManager.stores.GetStoreById(Id, trackChanges: false);

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
        [Authorize(Roles = "Administrator")]
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

            var response = await serviceManager.stores.CreateStore(storeDto);

            return CreatedAtRoute("StoreByID",new { Id = response.Id }, response);
        }

        [HttpDelete("{Id:Guid}")]
        [Authorize(Roles ="Administrator")]
        public async Task<IActionResult> DeleteStore(Guid Id)
        {
            try
            {
                if (Id.Equals(null))
                {
                    return UnprocessableEntity(ModelState);
                }

                await serviceManager.stores.DeleteStore(Id);

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

                await serviceManager.stores.UpdateStore(Id, updateModel, trackChanges: true);

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
