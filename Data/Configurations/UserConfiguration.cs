using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebsiteManagerPanel.Data.Entities;
using WebsiteManagerPanel.Data.Configurations.BaseConfigurations;

namespace WebsiteManagerPanel.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
        }
    }
}
