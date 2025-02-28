using System.ComponentModel.DataAnnotations;

namespace v1.DbContexts.Models
{
    public class CommonCollection : Common.TableOperationDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string MerchantName { get; set; }
        
        public string? MerchangeBasicId { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }

        [Required]
        public DateTime CollectionDate { get; set; }

        [Required]
        public decimal CollectedAmount { get; set; }

        [Required]
        public string BankName { get; set; }

        public string? CheckNumber { get; set; }
        public string? ClearingBranch { get; set; }
        public DateTime? CheckSubmissionDate { get; set; }

        [Required]
        public string CollectionOfficer { get; set; }

        [Required]
        public string Region { get; set; }

        public string? Memo { get; set; }

        public byte[]? FileAttachment { get; set; } // Store file as byte array

        // Navigation Property
        public ICollection<BillDetails> BillDetails { get; set; } = new List<BillDetails>();
    }
}
