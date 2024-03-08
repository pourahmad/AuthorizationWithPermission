namespace AuthorizationWithPermission.API.Models;

public class LoginResponseVm
{
    public UserDto User { get; set; }
    public string Token { get; set; }
}