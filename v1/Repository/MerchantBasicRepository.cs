using v1.DbContexts;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;

namespace v1.Repository;

public class MerchantBasicRepository : IMerchantBasicInterface
{
    private readonly MonitoringAppDbContext  _context;

    public MerchantBasicRepository(MonitoringAppDbContext context)
    {
        _context = context;
    }

    public async Task AddMerchantsAsync(List<MerchantBasicDetails> merchants)
    {
        await _context.MerchantBasicDetails.AddRangeAsync(merchants);
        await _context.SaveChangesAsync();
    }

    public async Task AddRegistrationAsync(MerchantRegistration registration)
    {
        await _context.MerchantRegistrations.AddAsync(registration);
        await _context.SaveChangesAsync();
    }
}