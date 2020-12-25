using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteManagerPanel.Query;
using WebsiteManagerPanel.Models;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace WebsiteManagerPanel.Service
{
    public class RoleService : IRoleService
    {
        private readonly RoleQuery _roleQuery;
        private readonly UserRoleQuery _userRoleQuery;
        public RoleService()
        {
        }
        public RoleService(RoleQuery roleQuery, UserRoleQuery userRoleQuery)
        {
            _roleQuery = roleQuery;
            _userRoleQuery = userRoleQuery;
        }

        public async Task<IServiceResponse<RoleViewModel>> GetRoleByIdAsync(int userId, int roleGroupID, Int64 roleID)
        {
            var response = new ServiceResponse<RoleViewModel>();
            RoleViewModel model = new RoleViewModel();
            var userRole = await _userRoleQuery.GetByUserIdAndRoleGroupId(userId, roleGroupID);
            if (userRole != null)
            {
                if (roleID == (userRole.Roles & roleID))
                {
                    var role = await _roleQuery.GetByRoleId(roleID);
                    if (role != null)
                    {
                        model = new RoleViewModel() { Id = role.Id, RoleName = role.RoleName, RoleGroupID = (int)userRole.RoleGroup.Id, RoleID = roleID, UserID = userId, GroupName = userRole.RoleGroup.GroupName };
                       
                    }
                }
                response.Entity = model;
            }
            return response;
        }

        public async Task<IServiceResponse<RoleViewModel>> GetRoleListByGroupIdAsync(int userId, int roleGroupID)
        {
            var response = new ServiceResponse<RoleViewModel>();
            List<RoleViewModel> model = new List<RoleViewModel>();
            var userRole = await _userRoleQuery.GetByUserIdAndRoleGroupId(userId, roleGroupID);
            if (userRole != null)
            {
                var allRoles = await _roleQuery.GetByRoleGroupIdRoles(roleGroupID);
                foreach (var role in allRoles)
                {
                    if (role.RoleId == (userRole.Roles & role.RoleId))
                    {
                        model.Add(new RoleViewModel() { Id = role.Id, RoleName = role.RoleName, RoleGroupID = (int)role.Group.Id, RoleID = (int)role.RoleId, UserID = userId, GroupName = role.Group.GroupName });
                    }
                }
                response.List = model;
            }
            return response;
        }
    }
}
