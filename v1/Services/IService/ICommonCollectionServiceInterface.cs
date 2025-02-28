using v1.DTOs;

namespace v1.Services.IService
{
    public interface ICommonCollectionServiceInterface
    {
        Task<CommonCollectionResponseDto> CreateAsync(CreateCommonCollectionDto dto, string createdBy);
        Task<List<CommonCollectionResponseDto>> GetAllAsync();
        Task<CommonCollectionResponseDto?> GetByIdAsync(Guid id);
        Task<bool> SoftDeleteAsync(Guid id, string deletedBy);
    }
}
