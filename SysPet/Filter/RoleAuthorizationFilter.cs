using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

public class RoleAuthorizationFilter : IAuthorizationFilter
{
    private readonly string _requiredRole;

    public RoleAuthorizationFilter(string requiredRole)
    {
        _requiredRole = requiredRole;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (user.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == _requiredRole))
        {
            // El usuario tiene el rol requerido
        }
        else
        {
            context.Result = context.Result = new ViewResult { ViewName = "AccessDenied" };  // Otra acción si el usuario no tiene el rol requerido
        }
    }
}
