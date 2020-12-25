using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using WebsiteManagerPanel.Framework.Extensions;
using WebsiteManagerPanel.Service;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Framework.Infrastructure
{
    public class PermissionFilter : IActionFilter
    {
        private readonly IRoleService _roleService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PermissionFilter(IRoleService roleService, IHttpContextAccessor httpContextAccessor)
        {
            _roleService = roleService;
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var user = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<SessionViewModel>("User");
            //Role Yetkisine bakılır.
            if (HasRoleAttribute(context))
            {
                try
                {
                    if (user == null || user.Id == 0)
                    {

                        context.HttpContext.Response.Redirect("/Auth/Login");

                    }
                    var arguments = ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.FirstOrDefault(fd => fd.AttributeType == typeof(RoleAttribute)).ConstructorArguments;

                    int roleGroupID = (int)arguments[0].Value;
                    Int64 roleID = (Int64)arguments[1].Value;
                    var role = _roleService.GetRoleByIdAsync(user.Id, roleGroupID, roleID).Result;
                    var data = role.Entity;
                    if (data == null || data?.Id == 0)
                    {
                        //Forbidden 403 Result. Yetkiniz Yoktur..
                        context.HttpContext.Response.Redirect("/Error/Auth");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result;
            // Do something with Result.
            if (context.Canceled == true)
            {
                // Action execution was short-circuited by another filter.
            }

            if (context.Exception != null)
            {
                // Exception thrown by action or action filter.
                // Set to null to handle the exception.
                context.Exception = null;
            }
        }

        public bool HasRoleAttribute(FilterContext context)
        {
            return ((ControllerActionDescriptor)context.ActionDescriptor).MethodInfo.CustomAttributes.Any(filterDescriptors => filterDescriptors.AttributeType == typeof(RoleAttribute));
        }


    }
}
