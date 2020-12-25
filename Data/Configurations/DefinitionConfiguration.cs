using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;
using WebsiteManagerPanel.Data.Entities;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class DefinitionConfiguration : AuditEntityTypeConfiguration<Definition>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Definition> builder)
        {
            builder.ToTable("Definitions");
            builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(8000);
            builder.HasOne(p => p.Site);
        }
    }
}
