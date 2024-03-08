using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthorizationWithPermission.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthorizationWithPermission.API.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;
    public TokenService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    public string GenerateToken(IdentityUser identityUser)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);

        var claimList = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, identityUser.UserName),
            new Claim(JwtRegisteredClaimNames.Email, identityUser.Email),
            new Claim(JwtRegisteredClaimNames.Sub, identityUser.Id)
        };

        var tokenDecriptor = new SecurityTokenDescriptor()
        {
            Audience = _jwtOptions.Audience,
            Issuer = _jwtOptions.Issuer,
            Subject = new ClaimsIdentity(claimList),
            Expires = DateTime.Now.AddSeconds(60),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDecriptor);

        return tokenHandler.WriteToken(token);
    }
}