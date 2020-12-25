using Microsoft.EntityFrameworkCore;
using WebsiteManagerPanel.Data.Configurations;
using WebsiteManagerPanel.Data.Entities;

namespace WebsiteManagerPanel.Data.Context
{
    public class DbDataContext : DbContext
    {

        public DbDataContext(DbContextOptions<DbDataContext> options)
            : base(options)
        {

        }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Definition> Definitions { get; set; }
        public DbSet<Field> Fields { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new DefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoleGroupConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
