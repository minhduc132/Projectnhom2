using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;
        private readonly IJwtAuth jwtAuth;

        public AuthenController(UserManager<IdentityUser> _userManager,
            SignInManager<IdentityUser>_signInManager,
            IAuth JwtAuth)
        {

        }
    }
}
