using Microsoft.EntityFrameworkCore;
using v1.DbContexts;
using v1.DbContexts.Models;
using v1.Repository.IRepository;

namespace v1.Repository
{
    public class CardTypeRepository : ICardTypeInterface
    {
        private readonly MonitoringAppDbContext _context;

        public CardTypeRepository(MonitoringAppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CardType>> GetAllAsync()
        {
            return await _context.CardTypes.ToListAsync();
        }

        public async Task<CardType> GetByIdAsync(Guid id)
        {
            return await _context.CardTypes.FindAsync(id);
        }

        public async Task<CardType> GetByNameAsync(string name)
        {
            return await _context.CardTypes.FirstOrDefaultAsync(ct => ct.CardTypeName == name);
        }

        public async Task AddAsync(CardType entity)
        {
            await _context.CardTypes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CardType entity)
        {
            _context.CardTypes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.CardTypes.FindAsync(id);
            if (entity != null)
            {
                _context.CardTypes.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}