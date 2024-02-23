using AuthorizationWithPermission.API.Data;
using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.API.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationSample.Services
{
    public class OrderService : IOrderService
    {
        private readonly AuthDbContext _context;
        public OrderService(AuthDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(Guid guid)
        {
            try
            {
                var order = _context.Orders.Find(guid);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Order>> GetAllListAsync()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order?> GetByIdAsync(Guid guid)
        {
            try
            {
                var oredr = await _context.Orders.FindAsync(guid);
                return oredr;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Order order)
        {
            try
            {
                var hasOrder = _context.Orders.Find(order.Id);
                if (hasOrder != null)
                {
                    //hasOrder.Products = order.Products;
                    //_context.Orders.Update(hasOrder);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
