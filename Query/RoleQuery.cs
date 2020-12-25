using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;

namespace WebsiteManagerPanel.Query
{
    public class RoleQuery : BaseQuery<Role>
    {
        public RoleQuery(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Role> GetByRoleId(long roleId)
        {
            var role = await Query.FirstOrDefaultAsync(p => p.RoleId == roleId);
            return role;
        }
        public async Task<List<Role>> GetByRoleGroupIdRoles(int roleGroupID)
        {
            var roles = await Query.Include(r => r.Group)
                    .Where(r => r.Group.Id == roleGroupID).ToListAsync();
            return roles;
        }
    }
}
