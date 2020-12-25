using System.Collections.Generic;
using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Entities
{
    //Her bir sayfaya, yani Controller’a karşılık gelen yetki tablosudur.
    public partial class RoleGroup:Entity
    {
        public string GroupName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        protected RoleGroup()
        {
            UserRoles = new List<UserRole>();
            Roles = new List<Role>();

        }
    }
}
