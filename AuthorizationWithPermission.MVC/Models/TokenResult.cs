namespace AuthorizationWithPermission.MVC.Models;

public class TokenResult
{
    public LoginResponseVm loginResponse  { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
}