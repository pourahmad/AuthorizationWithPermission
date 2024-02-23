using AuthenticationSample.Services;
using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithPermission.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionsService _permissionsService;
        public PermissionController(IPermissionsService permissionsService)
        {
            _permissionsService = permissionsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _permissionsService.GetAllListAsync();
            return Ok(result);  
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permission permission)
        {
            var result = await _permissionsService.AddAsync(permission);
            return Ok(result);
        }

        [HttpPost("AssignmentPermissionUser")]
        public async Task<IActionResult> AssignmentPermissionUser([FromQuery] string userId, string permissionId)
        {
            await _permissionsService.AssignmentPermissionUserAssync(userId, permissionId);
            return Ok();
        }
    }
}
