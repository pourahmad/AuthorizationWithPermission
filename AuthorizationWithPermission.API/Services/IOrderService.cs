using AuthorizationWithPermission.API.Entities;

namespace AuthorizationWithPermission.API.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllListAsync();
        Task<Order?> GetByIdAsync(Guid guid);
        Task<Order> AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid guid);
    }
}
