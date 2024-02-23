using Microsoft.AspNetCore.Identity;

namespace AuthorizationWithPermission.API.Entities
{
    public class UserPermission
    {
        public Guid Id { get; set; }
        public IdentityUser User { get; set; }
        public Permission Permission { get; set; }
    }
}
