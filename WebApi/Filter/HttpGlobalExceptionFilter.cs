using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.utils;

namespace WebApi.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Logger.Log.Warn("全局异常过滤器捕获的异常：", context.Exception);
        }
    }
}