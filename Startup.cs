using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using WebsiteManagerPanel.Data.Context;
using WebsiteManagerPanel.Framework.EF;
using WebsiteManagerPanel.Framework.Infrastructure;
using WebsiteManagerPanel.Framework.Interface;
using WebsiteManagerPanel.Framework.Middleware;
using WebsiteManagerPanel.Query;
using WebsiteManagerPanel.Service;

namespace WebsiteManagerPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbDataContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllersWithViews();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddMediatR(typeof(Startup));

            services.AddScoped<DbContext, DbDataContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped(typeof(IServiceResponse<>), typeof(ServiceResponse<>));
            services.AddScoped<PermissionFilter>();
            services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
            var humanTypes = typeof(BaseQuery<>).GetTypeInfo().Assembly.DefinedTypes
                .Where(t => t.IsClosedTypeOf(typeof(BaseQuery<>)) && t.IsClass)
                .Select(p => p.AsType());

            foreach (var humanType in humanTypes)
            {
                services.AddScoped(humanType);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseMiddleware<LoginMiddleware>(Options.Create(new MiddlewareOption { App = app }));
            app.UseMiddleware<ExceptionMiddleware>(Options.Create(new MiddlewareOption { App = app }));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
