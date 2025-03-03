using v1.DbContexts.Models;
using v1.DTOs;

namespace v1.Repository.IRepository;

public interface IMerchantBasicInterface
{
    Task<MerchantBasicDetails> CreateMerchantAsync(MerchantBasicDetails merchantBasic);
    Task<List<MerchantDto>> GetMerchantsAsync();
}