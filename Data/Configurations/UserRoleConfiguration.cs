using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasOne(p => p.RoleGroup);
            builder.HasOne(p => p.User);

        }
    }
}
