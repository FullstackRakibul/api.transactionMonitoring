using v1.DTOs;

namespace v1.Services.IService;

public interface IAdminDashBoardServiceInterface
{
    Task<CollectionMetricsSummaryDto>  GetCollectionMetricsSummaryAsync();
    
}