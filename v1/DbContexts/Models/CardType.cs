using System.ComponentModel.DataAnnotations;

namespace v1.DbContexts.Models;

public class CardType
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string CardTypeName { get; set; }
    public string? Details { get; set; }
}