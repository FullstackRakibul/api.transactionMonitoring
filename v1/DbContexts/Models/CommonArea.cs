namespace v1.DbContexts.Models;
using System.ComponentModel.DataAnnotations;

public class CommonArea
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
}