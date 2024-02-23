using AuthorizationWithPermission.API.Data;
using AuthorizationWithPermission.API.Entities;
using AuthorizationWithPermission.API.Models;
using AuthorizationWithPermission.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Immutable;
using System.Reflection;
using System.Security;

namespace AuthenticationSample.Services
{
    public class PermissionsService : IPermissionsService
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public PermissionsService(AuthDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Permission> AddAsync(Permission permission)
        {
            try
            {
                await _context.Permissions.AddAsync(permission);
                await _context.SaveChangesAsync();

                return permission;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AssignmentPermissionUserAssync(string userId, string permissionId)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(Guid.Parse(permissionId));
                var user = await _userManager.FindByIdAsync(userId);
                if (permission != null && user != null)
                {
                    await _context.UserPermissions.AddAsync(new UserPermission
                    {
                        Permission = permission,
                        User = user
                    });
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Permission>> GetAllListAsync()
        {
            try
            {
                var permissions = await _context.Permissions.OrderBy(o => o.Code).ToListAsync();
                return permissions;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<UserPermissionVm>> GetUserPermissionsAsync(string userId)
        {
            try
            {
                var result = await _context.UserPermissions
                    .Where(w => w.User.Id == userId)
                    .Join(_context.Permissions,
                       up => up.Permission.Id,
                       p => p.Id,
                       (up, p) => new UserPermissionVm
                       {
                           UserId = up.User.Id,
                           Code = p.Code,
                           Name = p.Name,
                           Title = p.Title,
                       }
                    ).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
