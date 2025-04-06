using v1.DTOs;

namespace v1.Repository.IRepository;

public interface IAdminDashboardInterface
{
    Task<CollectionMetricsSummaryDto> CollectionMetricsSummaryAsync();
}