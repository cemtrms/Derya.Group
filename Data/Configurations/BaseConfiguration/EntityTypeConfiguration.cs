using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities.Base;

namespace WebsiteManagerPanel.Data.Configurations.BaseConfigurations
{
    public abstract class EntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity, int> where TEntity : Entity<int>
    {

    }

    public abstract class EntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity<TId>
        where TId : struct, IComparable, IFormattable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            ConfigureEntity(builder);
        }
    }
}
