using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SysPet.Exception
{
    public class ManageExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ViewResult { ViewName = "CustomError" };
            context.ExceptionHandled = true;
        }
    }
}