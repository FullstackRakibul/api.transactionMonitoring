using v1.DTOs;
using v1.Repository.IRepository;
using v1.Services.IService;

namespace v1.Services;

public class MerchantBasicService :IMerchantBasicServiceInterface
{
    private readonly IMerchantBasicInterface  _merchantBasicInterface;

    public MerchantBasicService(IMerchantBasicInterface merchantBasicInterface)
    {
        _merchantBasicInterface = merchantBasicInterface;
    }
    
    
    // create merchant service 
    public Task<MerchantBasicDetailsDto> CreateAsync(MerchantBasicDetailsDto dto, string createdBy)
    {
        throw new NotImplementedException();
    }
}