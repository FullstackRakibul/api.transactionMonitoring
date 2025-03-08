using Microsoft.EntityFrameworkCore;
using v1.DbContexts;
using v1.DbContexts.Models;
using v1.Repository.IRepository;

namespace v1.Repository;

public class MerchantTypeRepository : IMerchantTypeInterface
{
    
    private readonly MonitoringAppDbContext _context;

    public MerchantTypeRepository(MonitoringAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MerchantType>> GetAllAsync()
    {
        return await _context.MerchantTypes.ToListAsync();
    }

    public async Task<MerchantType> GetMerchantTypeByIdAsync(Guid id)
    {
        return await _context.MerchantTypes.FirstOrDefaultAsync(data=>data.Id==id);
    }
    
    public async Task<MerchantType> GetByNameAsync(string name)
    {
        return await _context.MerchantTypes.FirstOrDefaultAsync(mt => mt.Name == name);
    }

    public async Task AddAsync(MerchantType entity)
    {
        await _context.MerchantTypes.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MerchantType entity)
    {
        _context.MerchantTypes.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.MerchantTypes.FindAsync(id);
        if (entity != null)
        {
            _context.MerchantTypes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}