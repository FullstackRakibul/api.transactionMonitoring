using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Common; 

namespace v1.DbContexts.Models
{
    public class MerchantRegistration : TableOperationDetails
    {
        [Key]
        public Guid Id { get; set; }
        
        // Foreign keys – using Guid? so they can be null if not yet set.
        public Guid? MerchantDetailsId { get; set; }
        public Guid? CardDetailsId { get; set; }
        public string? ApplicationUserId { get; set; }
        
        // The deposit amount from the check collection.
        public decimal? DepositCollection { get; set; }
        
        // VisitDate stored as DateOnly (requires .NET 6+); note that JSON binding may require a custom converter.
        public DateOnly? VisitDate { get; set; }
        
        // Navigation Properties
        [ForeignKey(nameof(MerchantDetailsId))]
        public MerchantBasicDetails MerchantBasicDetails { get; set; }
        
        [ForeignKey(nameof(CardDetailsId))]
        public CardDetails CardDetails { get; set; }
        
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}