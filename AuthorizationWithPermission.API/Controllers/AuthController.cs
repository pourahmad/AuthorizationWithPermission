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
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPermissionsService permissionsService, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _permissionsService = permissionsService;
            _tokenService = tokenService;
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


        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] UserLogin login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
                return NotFound();

            //var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.Remember, false);

            var checkPassword = await _userManager.CheckPasswordAsync(user, login.Password);
            if (!checkPassword)
                return NotFound();

            string token = _tokenService.GenerateToken(user);

            UserDto userDetails = new()
            {
                ID = user.Id,
                Name = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            LoginResponseVm loginResponse = new()
            {
                User = userDetails,
                Token = token,
            };
            return Ok(loginResponse);
        }

        [HttpGet(nameof(Logout))]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
