using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApi.Filter
{
    public class PermissionRequiredAttribute : ActionFilterAttribute
    {
        private readonly ILogger<PermissionRequiredAttribute> _logger;

        public PermissionRequiredAttribute(ILogger<PermissionRequiredAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var isDefined = false;
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                    .Any(a => a.GetType() == typeof(NoPermissionRequiredAttribute));
            }
            if (isDefined) return;
            if (context.HttpContext.Session.GetString("user") == null)
            {  
                context.Result = new BadRequestResult();
            }
            base.OnActionExecuting(context);
        }
    }

    public class NoPermissionRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
    }
}