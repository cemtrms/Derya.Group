using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class SiteConfiguration : AuditEntityTypeConfiguration<Site>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Site> builder)
        {
            builder.Property(p => p.Description).HasMaxLength(8000);
        }
    }
}
