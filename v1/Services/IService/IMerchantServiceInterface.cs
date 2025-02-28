
using v1.DTOs;

namespace v1.Services.IService;

public interface IMerchantServiceInterface
{
    Task<Guid> CreateMerchantAsync(MerchantDto merchantDto);
}