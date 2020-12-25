using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Configurations.BaseConfigurations
{
    public abstract class AuditEntityTypeConfiguration<TEntity> : AuditEntityTypeConfiguration<TEntity, int> where TEntity : AuditEntity<int>
    {

    }
    public abstract class AuditEntityTypeConfiguration<TEntity, TId> : EntityTypeConfiguration<TEntity, TId>
        where TEntity : AuditEntity<TId>
        where TId : struct, IComparable, IFormattable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true).IsRequired();
            builder.Property(p => p.CreateUserId).HasColumnName("CreatedBy").IsRequired();
            builder.Property(p => p.ModifyUserId).HasColumnName("ModifiedBy");

            builder.HasOne(p => p.CreateUser).WithMany().HasForeignKey(p => p.CreateUserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.ModifyUser).WithMany().HasForeignKey(p => p.ModifyUserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(p => p.IsActive);

            ConfigureEntity(builder);
        }
    }
}
