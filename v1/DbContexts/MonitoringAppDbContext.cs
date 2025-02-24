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
        
    }
}
