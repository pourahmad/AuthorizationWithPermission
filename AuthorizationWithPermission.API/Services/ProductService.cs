using AuthorizationWithPermission.API.Data;
using AuthorizationWithPermission.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationWithPermission.Services;
    public class ProductService : IProductService
    {
        private readonly AuthDbContext _context;
        public ProductService(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return product;
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
                var product = _context.Products.Find(guid);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllListAsync()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product?> GetByIdAsync(Guid guid)
        {
            try
            {
                var product = await _context.Products.FindAsync(guid);
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                var hasProduct = _context.Products.Find(product.Id);
                if (hasProduct != null)
                {
                    hasProduct.Name = product.Name;
                    _context.Products.Update(hasProduct);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
