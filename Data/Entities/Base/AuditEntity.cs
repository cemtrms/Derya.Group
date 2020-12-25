using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Framework.Exceptions;

namespace WebsiteManagerPanel.Data.Entities.Base
{
    public abstract class AuditEntity : AuditEntity<int>
    {

    }
    public abstract class AuditEntity<TId> : Entity<TId>
        where TId : IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public DateTime CreateDate { get; protected set; } = DateTime.Now;
        public int CreateUserId { get; protected set; }
        public virtual User CreateUser { get; set; }
        public DateTime? ModifyDate { get; protected set; }
        public int? ModifyUserId { get; protected set; }
        public virtual User? ModifyUser { get; protected set; }
        public bool IsActive { get; protected set; }

        public void Passive()
        {
            if (!IsActive)
                Argument.ThrowWorkflowException("Kayıt daha önceden pasife çekilmiştir.");
            IsActive = false;
        }
    }
}
