using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Common;

namespace v1.DbContexts.Models;
public class MerchantBasicDetails : TableOperationDetails
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public string Area { get; set; }

    [Required]
    public string Phone { get; set; }
    
    public DateTime? VisitDate { get; set; }
    // Foreign key to MerchantType (must match the type of MerchantType.Id)
    [Required]
    public Guid MerchantTypeId { get; set; } // Changed from string to Guid

    [ForeignKey(nameof(MerchantTypeId))]
    public MerchantType MerchantType { get; set; }
    
    public string? MerchantUserId { get; set; } 
}


