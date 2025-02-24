using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using v1.DbContexts;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;
using v1.Services;

namespace v1.Repository
{
    public class PublicRepository : IPublicInterface
    {
        private readonly MonitoringAppDbContext _indigoAppDbContext;
        private readonly PublicService _publicService;

        public  PublicRepository(MonitoringAppDbContext indigoAppDbContext) {
            _indigoAppDbContext = indigoAppDbContext;
        }

        public async Task<dynamic> GetPublicDataAsync()
        {
            var repoResponse = await _indigoAppDbContext.PublicData.ToListAsync();
            return "API Works ...";
        }
    }
}
