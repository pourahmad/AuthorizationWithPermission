using AuthorizationWithPermission.MVC.Models;
using AuthorizationWithPermission.MVC.Utilites;

namespace AuthorizationWithPermission.MVC.Services;

public class TokenService : ITokenService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public TokenService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    public void SetToken(string token)
    {
        _contextAccessor.HttpContext?.Response.Cookies.Append(ST.JWTToken, token);
    }

    public string? GetToken()
    {
        string? token = null;
        bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(ST.JWTToken, out token);
        return hasToken is true ? token : null;
    }

    public void ClearToken()
    {
        _contextAccessor.HttpContext?.Response.Cookies.Delete(ST.JWTToken);
    }
}