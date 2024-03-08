using AuthorizationWithPermission.MVC.Models;

namespace AuthorizationWithPermission.MVC.Services;

public interface ISigninService
{
    Task<TokenResult> SigninUserAsync(SigninVm signinVm);
}