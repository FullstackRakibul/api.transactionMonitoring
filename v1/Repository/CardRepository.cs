using v1.DbContexts;
using v1.DbContexts.Models;
using v1.Repository.IRepository;

namespace v1.Repository;

public class CardRepository : ICardInterface
{
    private readonly MonitoringAppDbContext _context;

    public CardRepository(MonitoringAppDbContext context)
    {
        _context = context;
    }

    public async Task AddCardsAsync(CardDetails cards)
    {
        await _context.CardDetails.AddRangeAsync(cards);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddCardsAsync(List<CardDetails> cards)
    {
        await _context.CardDetails.AddRangeAsync(cards); // Use AddRangeAsync
        await _context.SaveChangesAsync();
    }
    
}