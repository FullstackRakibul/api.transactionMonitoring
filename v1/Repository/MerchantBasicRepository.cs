using v1.DbContexts;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;

namespace v1.Repository;

public class MerchantBasicRepository : IMerchantBasicInterface
{
    private readonly MonitoringAppDbContext _context;

    public MerchantBasicRepository(MonitoringAppDbContext context)
    {
        _context = context;
    }
    
    // create merchant 
    public async Task<MerchantBasicDetails> CreateMerchantAsync(MerchantBasicDetails merchantBasic)
    {
        _context.MerchantBasicDetails.Add(merchantBasic);
        await _context.SaveChangesAsync();
        return merchantBasic;
    }

    public Task<List<MerchantDto>> GetMerchantsAsync()
    {
        throw new NotImplementedException();
    }
}