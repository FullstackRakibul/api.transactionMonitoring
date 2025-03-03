using v1.DTOs;

namespace v1.Services.IService;

public interface IMerchantBasicServiceInterface
{
    Task<MerchantDto> CreateAsync(MerchantDto dto, string createdBy);
}