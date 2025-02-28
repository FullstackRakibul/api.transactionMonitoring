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
        
        public DbSet<MerchantType> MerchantTypes { get; set; }
        public DbSet<MerchantBasicDetails> MerchantBasicDetails { get; set; }
        public DbSet<CommonArea> CommonAreas { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CardDetails> CardDetails { get; set; }
        public DbSet<MerchantRegistration> MerchantRegistrations { get; set; }
        
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
            
            
            modelBuilder.Entity<MerchantBasicDetails>()
                .HasOne(m => m.ApplicationUser)
                .WithMany()
                .HasForeignKey(m => m.MerchantUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MerchantBasicDetails>()
                .HasOne(m => m.MerchantType)
                .WithMany()
                .HasForeignKey(m => m.MerchantTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.MerchantBasicDetails)
                .WithMany()
                .HasForeignKey(mr => mr.MerchantDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.CardDetails)
                .WithMany()
                .HasForeignKey(mr => mr.CardDetailsId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.CommonArea)
                .WithMany()
                .HasForeignKey(mr => mr.AreaId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
