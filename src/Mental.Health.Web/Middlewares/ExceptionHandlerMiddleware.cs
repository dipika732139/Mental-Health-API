using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mental.Health.Web.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch(Exception exception)
            {
                await HandleException(exception, httpContext);
            }
        }

        public async Task HandleException(Exception exception, HttpContext context)
        {
            var appException = exception as BaseException;
            if (appException != null)
                context.Response.StatusCode = (int)appException.HttpStatusCode;
            else
            {
                appException = GetInternalServerError(context);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(appException));

        }
        private BaseException GetInternalServerError(HttpContext context)
        {
            return new BaseException(1,"");
        }
    }
}
