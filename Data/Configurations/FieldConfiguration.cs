using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class FieldConfiguration : AuditEntityTypeConfiguration<Field>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Field> builder)
        {
            builder.HasOne(p => p.Definition);
            builder.Property(p => p.Description).HasMaxLength(8000);
        }
    }
}
