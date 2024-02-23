using AuthorizationWithPermission.API.Models;
using AuthorizationWithPermission.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationWithPermission.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IPermissionsService _permissionsService;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPermissionsService permissionsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _permissionsService = permissionsService;
        }

        [HttpGet(nameof(GetAllUser))]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userManager.Users.ToListAsync();
            return Ok(result);
        }


        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(UserRegister register)
        {
            var user = new IdentityUser
            {
                UserName = register.UserName,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user: user, password: register.Password);
            return Ok(result);
        }


        [HttpGet(nameof(Login))]
        public async Task<IActionResult> Login([FromQuery] UserLogin login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
                return NotFound();

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.Remember, false);
            return Ok(result);
        }

        [HttpGet(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
