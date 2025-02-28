using v1.DTOs;

namespace v1.Repository.IRepository;

public interface IMerchantInterface
{
    Task AddMerchantAsync(MerchantDto merchant);
    Task<List<MerchantDto>> GetMerchantsAsync();
}