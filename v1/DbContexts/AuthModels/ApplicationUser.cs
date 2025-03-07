using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1.DbContexts.AuthModels
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string? Region { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public int Status { get; set; }
        public DateTime CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string? DeleteBy { get; set; }
        public DateTime DeleteAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
   