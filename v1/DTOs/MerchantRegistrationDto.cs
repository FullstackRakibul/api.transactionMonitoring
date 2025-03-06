namespace v1.DTOs;

public class MerchantRegistrationDto
{
    public List<MerchantBasicDetailsDto> Merchants { get; set; } = new();
    public List<CardDto> Cards { get; set; } = new();
}