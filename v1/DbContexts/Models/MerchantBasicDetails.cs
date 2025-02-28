using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Common;

namespace v1.DbContexts.Models;

public class MerchantBasicDetails : TableOperationDetails
{
    [Key]
    public string Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Area { get; set; }

    [Required]
    public string Phone { get; set; }

    public string? Remarks { get; set; }

    public DateTime? VisitDate { get; set; } // Nullable

    // Foreign Keys
    [Required]
    public string MerchantUserId { get; set; }
    [Required]
    public Guid MerchantTypeId { get; set; }
    // Navigation Properties
    [ForeignKey(nameof(MerchantUserId))]
    public ApplicationUser ApplicationUser { get; set; }

    [ForeignKey(nameof(MerchantTypeId))]
    public MerchantType MerchantType { get; set; }
}