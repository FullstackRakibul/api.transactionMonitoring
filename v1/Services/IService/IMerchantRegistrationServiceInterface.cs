using v1.DTOs;

namespace v1.Services.IService;

public interface IMerchantRegistrationServiceInterface
{
    Task RegisterMerchantAsync(MerchantRegistrationDto merchantRegistrationDto);
}