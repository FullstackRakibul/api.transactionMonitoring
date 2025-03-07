using v1.DbContexts.Models;

namespace v1.Repository.IRepository;

public interface IMerchantTypeInterface
{
    Task<IEnumerable<DbContexts.Models.MerchantType>> GetAllAsync();
    Task<dynamic> GetByIdAsync(string id);
    Task<MerchantType> GetByNameAsync(string name);
    Task AddAsync(DbContexts.Models.MerchantType entity);
    Task UpdateAsync(DbContexts.Models.MerchantType entity);
    Task DeleteAsync(Guid id);
}