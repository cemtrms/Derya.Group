using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebsiteManagerPanel.Framework.Extensions;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Framework.Middleware
{

    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationBuilder _app;
        public LoginMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor, IOptions<MiddlewareOption> options)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
            _app = options.Value.App;
        }
        public async Task Invoke(HttpContext context)
        {
            var user = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<SessionViewModel>("User");
            if(user==null)
            _app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}");
            });
            await _next(context);
        }
    }
}
