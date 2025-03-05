using v1.DbContexts.Models;

namespace v1.Repository.IRepository
{
    public interface ICardTypeInterface
    {
        Task<IEnumerable<CardType>> GetAllAsync();
        Task<CardType> GetByIdAsync(Guid id);
        Task<CardType> GetByNameAsync(string name);
        Task AddAsync(CardType entity);
        Task UpdateAsync(CardType entity);
        Task DeleteAsync(Guid id);
    }
}
