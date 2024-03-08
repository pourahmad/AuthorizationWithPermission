using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthorizationWithPermission.MVC.Models;
using AuthorizationWithPermission.MVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuthorizationWithPermission.MVC.Controllers;

public class LoginController : Controller
{
    private readonly ISigninService _signinService;
    private readonly ITokenService _tokenService;

    public LoginController(ISigninService signinService, ITokenService tokenService)
    {
        _signinService = signinService;
        _tokenService = tokenService;
    }

    // GET
    [HttpGet]
    public IActionResult Signin()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signin(SigninVm signinVm)
    {
        TokenResult responseVm = await _signinService.SigninUserAsync(signinVm);
        if (!responseVm.IsSuccess || responseVm.loginResponse == null)
        {
            ViewBag.LoginMessage = responseVm.Message;
            return View(signinVm);
        }
        
        _tokenService.SetToken(responseVm.loginResponse.Token);

        await SignInUser(responseVm.loginResponse);
        return RedirectToAction("Index", "Home");
    }
    
    private async Task SignInUser(LoginResponseVm model)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(model.Token);

        var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Email).Value));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Sub).Value));
        claimsIdentity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, jwt.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Name).Value));

        //claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(f => f.Type == JwtRegisteredClaimNames.Email).Value));
        //claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(f => f.Type == "role").Value));

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
    }
}