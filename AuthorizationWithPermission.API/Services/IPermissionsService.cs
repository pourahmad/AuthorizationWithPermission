using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.API.Models;
using System;

namespace AuthorizationWithPermission.API.Services
{
    public interface IPermissionsService
    {
        Task<List<Permission>> GetAllListAsync();
        Task<Permission> AddAsync(Permission permission);
        Task<List<UserPermissionVm>> GetUserPermissionsAsync(string userId);
        Task AssignmentPermissionUserAssync(string userId, string permissionId);
    }
}
