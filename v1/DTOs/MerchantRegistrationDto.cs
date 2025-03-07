using v1.DbContexts.AuthModels;

namespace v1.DTOs;


public class MerchantRegistrationDto
{
    public List<MerchantDto> Merchants { get; init; } = new();
    public List<UserVisitDto> UserVisits { get; init; } = new(); // Use UserVisitDto
    public decimal CheckCollection { get; init; }
    public DateTime VisitDate { get; init; }
    public List<CardDto> Cards { get; init; } = new();
}

public class UserVisitDto
{
    public string Name { get; set; }      // Rename from "merchantName"
    public string Area { get; set; }
    public string PhoneNumber { get; set; }
}
