using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.Attribute;
using AuthorizationWithPermission.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithPermission.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;

        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet]
        [PermissionAuthorization("GetAllProductList")]
        public async Task<IActionResult> Get()
        {
            var products = await _product.GetAllListAsync();
            return Ok(products);
        }

        [HttpGet("id")]
        [PermissionAuthorization("GetProductById")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _product.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        [PermissionAuthorization("AddProduct")]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            var result = await _product.AddAsync(product);
            return Created("Get", result.Id);
        }

        [HttpPut]
        [PermissionAuthorization("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            await _product.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete("id")]
        [PermissionAuthorization("DeleteProductById")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _product.DeleteAsync(id);
            return Ok();
        }

    }
}
