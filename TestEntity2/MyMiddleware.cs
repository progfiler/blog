using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEntity2;

namespace TestEntity2
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;

        public MyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public Task Invoke(HttpContext httpContext)
        {
            //var test = httpContext.Session.GetString("username");
            //var config = this._config
            //       .GetSection("ProtectedRoutes")
            //       .GetChildren()
            //       .Select(x => x.Value)
            //       .ToArray();
            //if (config.Contains(httpContext.Request.Path))
            //{
            //    if (test == null)
            //    {
            //        httpContext.Response.Redirect("/login");
            //    }
            //}
            return _next(httpContext);
        }
    }
}

public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}