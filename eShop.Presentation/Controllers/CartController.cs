using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using SharedAPI.Data_Transfer;

namespace eShop.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public CartController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        /// <summary>
        /// Gets a list of all products in cart for the logged in user from bearer token.
        /// </summary>
        /// <returns>A list of products in cart.</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProductsInCart()
        {
            var username = HttpContext?.User?.Identity?.Name;

            var response = await serviceManager.cart.GetCartProducts(username);

            return Ok(response);
        }

        /// <summary>
        /// Checkout products in cart for logged in user.
        /// </summary>
        [HttpPost("checkout")]
        [Authorize]
        public async Task<IActionResult> CheckoutProductsInCart()
        {
            var username = HttpContext?.User?.Identity?.Name;

            try
            {
                await serviceManager.cart.CheckoutCart(username);

                return NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPatch("id:Guid")]
        //public async Task<IActionResult> UpdateQty(Guid id, CartItemQtyUpdateDto cartItem)
        //{

        //}
    }
}
