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
    public class FieldItemConfiguration : AuditEntityTypeConfiguration<FieldItem>
    {
        public override void ConfigureEntity(EntityTypeBuilder<FieldItem> builder)
        {
            builder.HasOne(p => p.FieldValue);
        }
    }
}
