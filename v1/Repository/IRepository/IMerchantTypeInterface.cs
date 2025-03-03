using v1.DbContexts.Models;

namespace v1.Repository.IRepository;

public interface IMerchantTypeInterface
{
    Task<IEnumerable<DbContexts.Models.MerchantType>> GetAllAsync();
    Task<DbContexts.Models.MerchantType> GetByIdAsync(Guid id);
    Task<DbContexts.Models.MerchantType> GetByNameAsync(string name);
    Task AddAsync(DbContexts.Models.MerchantType entity);
    Task UpdateAsync(DbContexts.Models.MerchantType entity);
    Task DeleteAsync(Guid id);
}