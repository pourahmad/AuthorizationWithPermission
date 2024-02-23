namespace AuthorizationWithPermission.API.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
