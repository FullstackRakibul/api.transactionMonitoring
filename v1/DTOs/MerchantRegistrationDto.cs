namespace v1.DTOs;

public class MerchantRegistrationDto
{
    public List<MerchantDto> Merchants { get; set; } = new();
    public List<CardDto> Cards { get; set; } = new();
}