namespace AuthorizationWithPermission.MVC.Models;

public class SigninVm
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Remember { get; set; }
}