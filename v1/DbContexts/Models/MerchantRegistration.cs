using v1.DbContexts.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v1.DbContexts.Models;

public class MerchantRegistration : TableOperationDetails
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string? MerchantDetailsId { get; set; }

    [Required]
    public Guid? CardDetailsId { get; set; }
    public Guid? AreaId { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(MerchantDetailsId))]
    public MerchantBasicDetails MerchantBasicDetails { get; set; }

    [ForeignKey(nameof(CardDetailsId))]
    public CardDetails CardDetails { get; set; }

    [ForeignKey(nameof(AreaId))]
    public CommonArea CommonArea { get; set; }
}