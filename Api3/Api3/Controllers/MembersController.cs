using Api3.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        private readonly List<Member> member1 = new List<Member>()
        {
             new Member{Id=1,Name="Name 1"},
            new Member{Id=2,Name="Name 2"},
             new Member{Id=3,Name="Name 3"},

        };
        public MembersController(IJwtAuth jwtAuth,
            UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser> _signInManager)
        {
            this.jwtAuth = jwtAuth;
            this._userManager = _userManager;
            this._signInManager = _signInManager;
        }
    
    [AllowAnonymous]
        // Post api/<MembersController>
        [HttpPost("authentication")]


        public async Task<IActionResult> Authentication([FromBody] UserCredential userCredential)
        {
            var result = await _signInManager.PasswordSignInAsync(userCredential.UserName,
                userCredential.Password, false, false);
            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        [AllowAnonymous]
        //Post api<Members/register
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserCredential userCredential)
        {
            var user = new IdentityUser
            {
                UserName = userCredential.UserName,
                Email = userCredential.UserName
            };

            var result = await _userManager.CreateAsync(user, userCredential.Password);
            if (result.Succeeded)
            {
                return Ok(userCredential.UserName);
            }

            return Unauthorized();
        }
        //public IActionResult Authentication([FromBody] UserCredential userCredential)
        //{
        //    var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
        //    if (token == null)
        //        return Unauthorized();
        //    return Ok(token);
        // }
        //Get:api/Members
        [HttpGet]
        public IEnumerable<Member> AllMembers()
        {
            return member1;
        }
    }

}
