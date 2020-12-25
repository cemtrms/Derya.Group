using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.Middleware
{
    public static class RequestLoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogin(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
