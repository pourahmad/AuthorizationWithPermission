namespace AuthorizationWithPermission.MVC.Models;

public class LoginResponseVm
{
    public UserVm User { get; set; }
    public string Token { get; set; }
}