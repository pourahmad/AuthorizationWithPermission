using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.API.Services;
using AuthorizationWithPermission.Attribute;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpGet]
        [PermissionAuthorization("GetAllOredrList")]
        public async Task<IActionResult> Get() 
        {
            var orders = await _order.GetAllListAsync();
            return Ok(orders); 
        }

        [HttpGet("id")]
        [PermissionAuthorization("GetOrderById")]
        public async Task<IActionResult> Get(Guid id) 
        {
            var order = await _order.GetByIdAsync(id);
            return Ok(order); 
        }

        [HttpPost]
        [PermissionAuthorization("AddOrder")]
        public async Task<IActionResult> Post([FromBody] Order order) 
        {
            var result = await _order.AddAsync(order);
            return Created();
        }

        [HttpPut]
        [PermissionAuthorization("UpdateOrder")]
        public async Task<IActionResult> Put([FromBody] Order order) 
        {
            await _order.UpdateAsync(order);
            return Ok(); 
        }

        [HttpDelete("id")]
        [PermissionAuthorization("DeleteOrderById")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            await _order.DeleteAsync(id);
            return Ok();
        }
    }
}
