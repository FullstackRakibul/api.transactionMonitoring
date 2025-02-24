using Microsoft.AspNetCore.Identity;

namespace v1.DbContexts.AuthModels
{
    public class ApplicationRole : IdentityRole
    {
        public string? Description { get; set; }
        public int? Status { get; set; }
    }
}
