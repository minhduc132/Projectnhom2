using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServerApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuth jwtAuth;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
      

        public AuthenController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager, IAuth jwtAuth)
        {
            this._userManager = _userManager;
            this._signInManager = _signInManager;
            this.jwtAuth = jwtAuth;
        }

        
        //register
        [AllowAnonymous]
        //GET: api/Authen/MemberController
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] User userCredential)
        {
            //thong bao
            ReturnValue rv = new ReturnValue();

            var user = new IdentityUser
            {
                UserName = userCredential.Username,
                Email = userCredential.Username
            };
            var result = await _userManager.CreateAsync(user, userCredential.Password);
            if (result.Succeeded)
            {
                rv.Code = "Success";
                rv.Message = "Tao user thanh cong";
                //
            }
            else
            {
                rv.Code = "Fail";
                rv.Message = result.Errors.ToList().ToString();
            }
            return Ok(rv);
        }

        //login
        [AllowAnonymous]
        //GET: api/<MemberController
        [HttpPost("authentication")]

        public async Task<IActionResult> AuthenticationAsync([FromBody] User userCredential)
        {
            var result = await _signInManager.PasswordSignInAsync(
                userCredential.Username,
                userCredential.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = jwtAuth.Authentication(userCredential.Username,
                userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);

        }
    }
}
