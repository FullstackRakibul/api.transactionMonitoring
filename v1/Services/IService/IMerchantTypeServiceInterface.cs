using v1.DTOs;

namespace v1.Services.IService;

public interface IMerchantTypeServiceInterface
{
    Task<MerchantTypeDto> CreateMerchantTypeAsync(MerchantTypeDto dto, string createdBy);
    Task<IEnumerable<MerchantTypeDto>> GetAllMerchantTypesAsync();
}