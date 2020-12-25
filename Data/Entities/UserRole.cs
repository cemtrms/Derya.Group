using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Entities
{
    public partial class UserRole: Entity
    {
      
        public long? Roles { get; set; }
        public virtual RoleGroup RoleGroup { get; set; }
        public virtual User ?User { get; set; }
    }
}
