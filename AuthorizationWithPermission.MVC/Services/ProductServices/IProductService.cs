
using AuthorizationWithPermission.MVC.Models.Product;

namespace AuthorizationWithPermission.MVC.Services.ProductServices;

public interface IProductService
{
    Task<List<ProductVm>> GetAllListAsync();
    Task<ProductVm?> GetByIdAsync(Guid guid);
    Task<ProductVm> AddAsync(ProductVm product);
    Task UpdateAsync(ProductVm product);
    Task DeleteAsync(Guid guid);
}