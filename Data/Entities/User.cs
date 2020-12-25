using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Commands.UsersInsertCommand;
using WebsiteManagerPanel.Data.Entities.Base;
using WebsiteManagerPanel.Framework.Interfaces;

namespace WebsiteManagerPanel.Data.Entities
{
    public partial class User:Entity, IAggreegateRoot
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<UserRole> UserRoles { get;protected set; }
       
        protected User()
        {
            UserRoles = new List<UserRole>();
        }
        public User(UserInsertCommand request,byte[] passwordHash,byte[] passwordSalt)
        {
            Email = request.Email;
            FirstName = request.FirstName;
            LastName = request.LastName;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            IsActive = true;
        }
    }
}
