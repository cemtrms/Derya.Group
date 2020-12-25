using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Role> builder)
        {
            builder.HasOne(p => p.Group);

        }
    }
}
