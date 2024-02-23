using AuthorizationWithPermission.API.Entities;

namespace AuthorizationWithPermission.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllListAsync();
        Task<Product?> GetByIdAsync(Guid guid);
        Task<Product> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid guid);
    }
}
