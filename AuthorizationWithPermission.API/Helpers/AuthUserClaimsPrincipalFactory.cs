using AuthorizationWithPermission.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace AuthorizationWithPermission.API.Helpers
{
    public class AuthUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<IdentityUser, IdentityRole>
    {
        private readonly IPermissionsService _permissionsService;
        public AuthUserClaimsPrincipalFactory(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options, IPermissionsService permissionsService) : base(userManager, roleManager, options)
        {
            _permissionsService = permissionsService;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(IdentityUser user)
        {
            var identities = await base.GenerateClaimsAsync(user);

            var permissions = await _permissionsService.GetUserPermissionsAsync(userId: user.Id);

            IList<Claim> claims = new List<Claim>();
            foreach (var permit in permissions)
            {
                claims.Add(new Claim(permit.Name, permit.Name));
            }

            identities.AddClaims(claims);
            return identities;
        }
    }
}