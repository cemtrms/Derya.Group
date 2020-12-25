using System;
using System.Threading.Tasks;
using WebsiteManagerPanel.Models;

namespace WebsiteManagerPanel.Service
{
    public interface IRoleService
    {
        public Task<IServiceResponse<RoleViewModel>> GetRoleByIdAsync(int userId, int roleGroupID, Int64 roleID);
        public Task<IServiceResponse<RoleViewModel>> GetRoleListByGroupIdAsync(int userId, int roleGroupID);
    }
}
