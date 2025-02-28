using v1.DbContexts.Models;
using v1.DbContexts;
using v1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace v1.Repository
{
    public class CommonCollectionRepository : ICommonCollectionInterface
    {
        private readonly MonitoringAppDbContext _context;

        public CommonCollectionRepository(MonitoringAppDbContext context)
        {
            _context = context;
        }

        public async Task<CommonCollection> CreateAsync(CommonCollection commonCollection)
        {
            _context.CommonCollections.Add(commonCollection);
            await _context.SaveChangesAsync();
            return commonCollection;
        }

        public async Task<List<CommonCollection>> GetAllAsync()
        {
            return await _context.CommonCollections
                .Include(cc => cc.BillDetails)
                .ToListAsync();
        }

        public async Task<CommonCollection?> GetByIdAsync(Guid id)
        {
            return await _context.CommonCollections
                .Include(cc => cc.BillDetails).Where(data=>data.IsDeleted==false)
                .FirstOrDefaultAsync(cc => cc.Id == id);
        }

        public async Task<bool> SoftDeleteAsync(Guid id, string deletedBy)
        {
            var collection = await _context.CommonCollections.FindAsync(id);
            if (collection == null) return false;

            collection.IsDeleted = true;
            collection.DeleteBy = deletedBy;
            collection.DeleteAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
