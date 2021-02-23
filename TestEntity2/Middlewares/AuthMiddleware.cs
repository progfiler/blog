using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEntity2.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private IConfiguration _config;
        public AuthMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var userId = httpContext.Session.GetInt32("userId");
            var protectedRoutes = this._config
             .GetSection("ProtectedRoutes")
             .GetChildren()
             .Select(x => x.Value)
             .ToList();
            var test = protectedRoutes.Contains(httpContext.Request.Path.Value);
            if (!protectedRoutes.Contains(httpContext.Request.Path.Value) && userId == null)
            {
                return _next(httpContext);
            }
            else
            {
                if (userId == null)
                {
                    httpContext.Response.Redirect("/Auth/Login");
                    return _next(httpContext);
                }
                else
                {
                    return _next(httpContext);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
