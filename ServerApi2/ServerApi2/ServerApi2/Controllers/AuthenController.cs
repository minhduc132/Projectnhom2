using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerApi2;
using ServerApi2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAPI.Controllers
{
    [Authorize]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuth jwtAuth;

        public AuthenController(UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager,
            IAuth jwtAuth)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this.jwtAuth = jwtAuth;
        }
        //register
        [AllowAnonymous]
        // POST api/Authen/register
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] User userCredential)
        {
            ReturnValue rv = new ReturnValue();
            var user = new IdentityUser
            {
                UserName = userCredential.UserName,
                Email = userCredential.Email
            };
            var result = await _userManager.CreateAsync(user, userCredential.Password);
            if (result.Succeeded)
            {
                rv.Code = "OK";
                rv.Message = "Tao user thanh cong";
            } else
            {
                rv.Code = "FAIL";
                rv.Message = result.Errors.ToList().ToString();
            }
            return Ok(rv);
            //return Unauthorized();
        }
        //login
        [AllowAnonymous]
        // POST api/authen/authentication
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication(
            [FromBody] User userCredential)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userCredential.UserName,
                userCredential.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = jwtAuth.Authentication(userCredential.UserName,
                userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
            //return Ok(new { token = token });
        }
    }
}
