using System.Net.Http.Headers;
using AuthorizationWithPermission.MVC.Models.Product;
using AuthorizationWithPermission.MVC.Utilites;

namespace AuthorizationWithPermission.MVC.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly ITokenService _tokenService;

    public ProductService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public Task<List<ProductVm>> GetAllListAsync()
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =new AuthenticationHeaderValue("Bearer", _tokenService.GetToken());
            var products = httpClient.GetFromJsonAsync<List<ProductVm>>($"{ST.ApiServiceBaseurl}/Product");
            return products;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ProductVm?> GetByIdAsync(Guid guid)
    {
        throw new NotImplementedException();
    }

    public Task<ProductVm> AddAsync(ProductVm product)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(ProductVm product)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid guid)
    {
        throw new NotImplementedException();
    }
}