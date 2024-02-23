namespace AuthorizationWithPermission.Attribute;

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class PermissionAuthorizationAttribute : Attribute, IAuthorizationFilter
{
    private string _permission;
    public PermissionAuthorizationAttribute(string permission) : base()
    {
        _permission = permission;
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {

        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        bool isAccess = context.HttpContext.User
        .HasClaim(c => c.Value.ToLower() == _permission.ToLower());

        if (isAccess)
            return;

        context.Result = new UnauthorizedResult();
    }
}

