namespace v1.DTOs;

public class CollectionMetricsSummaryDto
{
    public decimal TotalCollection { get; set; }
    public decimal TodaysCollection { get; set; }
    public int MerchantRegistrationsCount { get; set; }
    public int MerchantVisitsCount { get; set; }
}