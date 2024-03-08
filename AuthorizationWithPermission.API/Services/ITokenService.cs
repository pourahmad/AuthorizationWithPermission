using AuthorizationWithPermission.API.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthorizationWithPermission.API.Services;

public interface ITokenService
{
    string GenerateToken(IdentityUser identityUser);
}