using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public class AuthorizePermissionAttribute : ActionFilterAttribute
{
    public string RequiredRole { get; set; }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.User.HasPermisionRole(RequiredRole))
        {
            context.Result = new ForbidResult(); // Otra opción es redirigir a una vista de acceso denegado
        }

        base.OnActionExecuting(context);
    }
}
