using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;

namespace WebsiteManagerPanel.Query
{
    public class UserRoleQuery : BaseQuery<UserRole>
    {
        public UserRoleQuery(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserRole> GetByUserIdAndRoleGroupId(int userId, int roleGroupId)
        {
            var userRole = await Query.Include(p => p.RoleGroup).FirstOrDefaultAsync(ur => ur.User.Id == userId && ur.RoleGroup.Id == roleGroupId);
            return userRole;
        }
        public async Task<UserRole> GetUserRole(int userId, int roleGroupID)
        {
            var userRole = await Query
            .Include(r => r.RoleGroup)
                .ThenInclude(p => p.Roles)
                .Include(p => p.User)
                .FirstOrDefaultAsync(ur => ur.User.Id == userId && ur.RoleGroup.Id == roleGroupID);
            return userRole;
        }
    }
}
