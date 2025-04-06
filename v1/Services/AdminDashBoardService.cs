using v1.DTOs;
using v1.Services.IService;

namespace v1.Services;

public class AdminDashBoardService : IAdminDashBoardServiceInterface
{
    public Task<CollectionMetricsSummaryDto> GetCollectionMetricsSummaryAsync()
    {
        throw new NotImplementedException();
    }
}