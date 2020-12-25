using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebsiteManagerPanel.Framework.Exceptions;

namespace WebsiteManagerPanel.Framework.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder _app;
        public ExceptionMiddleware(RequestDelegate next, IOptions<MiddlewareOption> options)
        {
            _next = next;
            _app = options.Value.App;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(context, e);
            }
        }
        private  Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Sunucu erişimi yok";
            if(e.GetType()==typeof(ValidationException))
            {
                message = e.Message;
            }

            if (httpContext.Response.StatusCode == 401 && !httpContext.Response.HasStarted)
            {
                httpContext.Response.Redirect("/Error/PageNotFound");
            }

            if (httpContext.Response.StatusCode == 404 && !httpContext.Response.HasStarted)
            {
                httpContext.Response.Redirect("/Error/PageNotFound");

            }

            if (httpContext.Response.StatusCode == 500 && !httpContext.Response.HasStarted)
            {
                httpContext.Response.Redirect("/Error/InternalServerError");

            }

            _app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}");
            });

            return  httpContext.Response.WriteAsync(new ErrorDetail(message, httpContext.Response.StatusCode).ToString());
        }
    }
}
