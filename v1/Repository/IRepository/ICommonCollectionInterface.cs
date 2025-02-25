using v1.DbContexts.Models;

namespace v1.Repository.IRepository
{
    public interface ICommonCollectionInterface
    {
        Task<CommonCollection> CreateAsync(CommonCollection commonCollection);
        Task<List<CommonCollection>> GetAllAsync();
        Task<CommonCollection?> GetByIdAsync(Guid id);
        Task<bool> SoftDeleteAsync(Guid id, string deletedBy);
    }
}
