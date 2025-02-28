using System.ComponentModel.DataAnnotations;

namespace v1.DbContexts.Models;

public class MerchantType
{
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
}