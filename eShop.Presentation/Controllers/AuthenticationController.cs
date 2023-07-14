using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.Data_Transfer;

namespace eShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AuthenticationController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto user)
        {
            if (user is null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "User Creation Object Can Not Be Null"
                });
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var result = await serviceManager.auth.RegisterUser(user);

            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201, "Registration successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserDto user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "User Creation Object Can Not Be Null"
                    });
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                var IsAuthenticated = await serviceManager.auth.AuthenticateUser(user);

                if(!IsAuthenticated)
                {
                    return Unauthorized(new
                    {
                        StatusCode = 401,
                        Message = "Invalid Username/Password"
                    });
                }

                var token = await serviceManager.auth.CreateToken(populateExp: true);

                return Ok(token);
            }catch(Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }

        }

        [HttpPost("refresh-token")]
        [Authorize]
        public async Task<IActionResult> RefreshToken([FromBody] TokenDto token)
        {
            if(token is null)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Refresh Token Object Can Not Be Null"
                });
            }

            var newToken = await serviceManager.auth.RefreshToken(token.accessToken, token.refreshToken);

            return Ok(newToken);
        }
        //[HttpGet("token")]
        //public ActionResult Auth()
        //{
        //    var properties = new AuthenticationProperties()
        //    {
        //        ///api/authentication/MyExternalLoginBack
        //        RedirectUri = $"api/authentication/MyExternalLoginBack",
        //        Items =
        //        {
        //            { "LoginProvider", "Google" },
        //        },
        //        AllowRefresh = true,
        //    };

        //    return Challenge(properties, "Google");
        //}
    }
}
