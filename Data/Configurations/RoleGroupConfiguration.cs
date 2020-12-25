using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class RoleGroupConfiguration : EntityTypeConfiguration<RoleGroup>
    {
        public override void ConfigureEntity(EntityTypeBuilder<RoleGroup> builder)
        {
        }
    }
}
