using System.ComponentModel.DataAnnotations;

namespace v1.DTOs;

public class MerchantBasicDetailsDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Area { get; set; }
    [Required]
    public string Phone { get; set; }
    public string? Remarks { get; set; }
    public DateTime? VisitDate { get; set; }
    [Required]
    public Guid MerchantTypeId { get; set; }
}