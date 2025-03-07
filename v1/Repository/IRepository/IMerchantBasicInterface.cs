using v1.DbContexts.Models;
using v1.DTOs;

namespace v1.Repository.IRepository;

public interface IMerchantBasicInterface
{
    Task AddMerchantsAsync(List<MerchantBasicDetails> merchants);
    Task AddRegistrationAsync(MerchantRegistration registration);
}