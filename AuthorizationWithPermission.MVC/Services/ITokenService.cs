using AuthorizationWithPermission.MVC.Models;

namespace AuthorizationWithPermission.MVC.Services;

public interface ITokenService
{
    void SetToken(string token);
    string? GetToken();
    void ClearToken();
}