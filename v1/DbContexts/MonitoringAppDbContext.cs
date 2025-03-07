using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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

            modelBuilder.Entity<MerchantBasicDetails>()
                .HasOne(m => m.MerchantType)
                .WithMany()
                .HasForeignKey(m => m.MerchantTypeId) // Foreign key is MerchantTypeId (Guid)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Configure decimal properties with precision and scale
            modelBuilder.Entity<BillDetails>()
                .Property(b => b.BillingAmount)
                .HasPrecision(18, 2); // Example: 18 total digits, 2 decimal places

            modelBuilder.Entity<CommonCollection>()
                .Property(c => c.CollectedAmount)
                .HasPrecision(18, 2); // Example: 18 total digits, 2 decimal places

            // Example: 18 total digits, 2 decimal places

            // One-to-Many Relationship: CommonCollection -> BillDetails
            modelBuilder.Entity<CommonCollection>()
                .HasMany(cc => cc.BillDetails)
                .WithOne(bd => bd.CommonCollection)
                .HasForeignKey(bd => bd.CommonCollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Optional: Configure IdentityUserLogin<string> Primary Key if needed
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            
            modelBuilder.Entity<CardDetails>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.ApplicationUserId);

            modelBuilder.Entity<CardDetails>()
                .HasOne(c => c.CardType)
                .WithMany()
                .HasForeignKey(c => c.CardTypeId);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.MerchantBasicDetails)
                .WithMany()
                .HasForeignKey(mr => mr.MerchantDetailsId);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.CardDetails)
                .WithMany()
                .HasForeignKey(mr => mr.CardDetailsId);

            modelBuilder.Entity<MerchantRegistration>()
                .HasOne(mr => mr.ApplicationUser)
                .WithMany()
                .HasForeignKey(mr => mr.ApplicationUserId);
        }
        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // Identity configuration (don't forget this)
        //     base.OnModelCreating(modelBuilder);
        //
        //     // One-to-Many Relationship: CommonCollection -> BillDetails
        //     modelBuilder.Entity<CommonCollection>()
        //         .HasMany(cc => cc.BillDetails)
        //         .WithOne(bd => bd.CommonCollection)
        //         .HasForeignKey(bd => bd.CommonCollectionId)
        //         .OnDelete(DeleteBehavior.Cascade);
        //
        //     // Optional: Configure IdentityUserLogin<string> Primary Key if needed
        //     modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
        //     
        //     
        //     // Configure relationships and constraints
        //     modelBuilder.Entity<MerchantBasicDetails>()
        //         .HasOne(m => m.MerchantType)
        //         .WithMany()
        //         .HasForeignKey(m => m.MerchantTypeId);
        //
        //     modelBuilder.Entity<CardDetails>()
        //         .HasOne(c => c.User)
        //         .WithMany()
        //         .HasForeignKey(c => c.ApplicationUserId);
        //
        //     modelBuilder.Entity<CardDetails>()
        //         .HasOne(c => c.CardType)
        //         .WithMany()
        //         .HasForeignKey(c => c.CardTypeId);
        //
        //     modelBuilder.Entity<MerchantRegistration>()
        //         .HasOne(mr => mr.MerchantBasicDetails)
        //         .WithMany()
        //         .HasForeignKey(mr => mr.MerchantDetailsId);
        //
        //     modelBuilder.Entity<MerchantRegistration>()
        //         .HasOne(mr => mr.CardDetails)
        //         .WithMany()
        //         .HasForeignKey(mr => mr.CardDetailsId);
        //
        //     modelBuilder.Entity<MerchantRegistration>()
        //         .HasOne(mr => mr.ApplicationUser)
        //         .WithMany()
        //         .HasForeignKey(mr => mr.ApplicationUserId);
        //     
        // }
    }
}
