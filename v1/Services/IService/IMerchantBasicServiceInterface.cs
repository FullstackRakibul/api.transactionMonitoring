using v1.DTOs;

namespace v1.Services.IService;

public interface IMerchantBasicServiceInterface
{
    Task<MerchantBasicDetailsDto> CreateAsync(MerchantBasicDetailsDto dto, string createdBy);
}