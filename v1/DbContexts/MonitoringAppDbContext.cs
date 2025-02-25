using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Models;


namespace v1.DbContexts
{
    public class MonitoringAppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MonitoringAppDbContext(DbContextOptions<MonitoringAppDbContext> options)
            : base(options)
        {

        }

        public DbSet<PublicData> PublicData { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }

        public DbSet<CommonCollection> CommonCollections { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Identity configuration (don't forget this)
            base.OnModelCreating(modelBuilder);

            // One-to-Many Relationship: CommonCollection -> BillDetails
            modelBuilder.Entity<CommonCollection>()
                .HasMany(cc => cc.BillDetails)
                .WithOne(bd => bd.CommonCollection)
                .HasForeignKey(bd => bd.CommonCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Configure IdentityUserLogin<string> Primary Key if needed
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }

    }
}
