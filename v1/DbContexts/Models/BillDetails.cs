using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace v1.DbContexts.Models
{
    public class BillDetails : Common.TableOperationDetails
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CommonCollectionId { get; set; } // Foreign Key

        [Required]
        public int BillingYear { get; set; }

        [Required]
        public int BillingMonth { get; set; }

        [Required]
        public decimal BillingAmount { get; set; }

        // Navigation Property
        [ForeignKey(nameof(CommonCollectionId))]
        public CommonCollection CommonCollection { get; set; }
    }
}
