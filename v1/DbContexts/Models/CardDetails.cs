using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Common;

namespace v1.DbContexts.Models;

public class CardDetails : TableOperationDetails
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? ApplicationUserId { get; set; }
    public string CardDetailsName { get; set; }
    public string? BankName { get; set; }
    public string? CardHolderName { get; set; }
    public int? CardNumber { get; set; }
    public int? ValidMonth { get; set; }
    public int? ValidYear { get; set; }
    public int? SignatureNumber { get; set; }
    public int? Phone { get; set; }

    [Required]
    public Guid CardTypeId { get; set; }
    // Navigation Properties
    [ForeignKey(nameof(ApplicationUserId))]
    public ApplicationUser User { get; set; }
    
    [ForeignKey(nameof(CardTypeId))]
    public CardType CardType { get; set; }
}