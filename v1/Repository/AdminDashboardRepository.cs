using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using v1.DbContexts;
using v1.DbContexts.AuthModels;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;

namespace v1.Repository;

public class AdminDashboardRepository : IAdminDashboardInterface
{
    private readonly MonitoringAppDbContext  _context;
    
    public AdminDashboardRepository(MonitoringAppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<CollectionMetricsSummaryDto> CollectionMetricsSummaryAsync()
    {
        var today = DateTime.Today;

        // var result = await (from cmncl in _context.CommonCollections
        //     join bill in _context.BillDetails on cmncl.Id equals bill.CommonCollectionId
        //     join baseMerchant in _context.MerchantBasicDetails on cmncl.MerchantBasicId equals baseMerchant.Id
        //     join usr in _context.AspNetUsers on baseMerchant.MerchantUserId equals usr.Id into userGroup
        //     from usr in userGroup.DefaultIfEmpty() // Left join
        //     group new { cmncl, baseMerchant, usr } by 1 into g // Group by a constant to aggregate
        //     select new CollectionMetricsSummaryDto
        //     {
        //         TotalCollectedAmount = g.Sum(x => x.cmncl.CollectedAmount),
        //         TodayCollectedAmount = g.Sum(x => x.cmncl.CollectionDate.Date == today ? x.cmncl.CollectedAmount : 0),
        //         TotalMerchants = g.Count(),
        //         InactiveUserCount = g.Count(x => x.usr != null && x.usr.Status == 0)
        //     }).FirstOrDefaultAsync();
        //
        // return result ?? new CollectionMetricsSummaryDto(); 
        throw new NotImplementedException();
    }
}