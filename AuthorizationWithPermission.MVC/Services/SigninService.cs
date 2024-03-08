using System.Text;
using AuthorizationWithPermission.MVC.Models;
using AuthorizationWithPermission.MVC.Utilites;
using Newtonsoft.Json;

namespace AuthorizationWithPermission.MVC.Services;

public class SigninService : ISigninService
{
    public SigninService()
    {
    }

    public async Task<TokenResult> SigninUserAsync(SigninVm signinVm)
    {
        try
        {
            HttpClient httpClient = new();
            var uri = new Uri($"{ST.ApiServiceBaseurl}/Auth/Login");
            var response = await httpClient.PostAsJsonAsync(uri, signinVm);
            
            if (!response.EnsureSuccessStatusCode().IsSuccessStatusCode && response.Content.ReadAsStreamAsync() == null)
                return new TokenResult
                {
                    IsSuccess = false,
                    Message = "Token not generated!",
                    loginResponse = null
                };

            var userWithToken = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonConvert.DeserializeObject<LoginResponseVm>(userWithToken);
            return new TokenResult
            {
                IsSuccess = true,
                Message = "Token Generated.",
                loginResponse = loginResponse
            };
        }
        catch (Exception e)
        {
            return new TokenResult
            {
                IsSuccess = false,
                Message = e.Message,
                loginResponse = null
            };
        }
    }
}