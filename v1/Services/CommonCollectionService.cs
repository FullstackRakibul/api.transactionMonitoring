

using Microsoft.AspNetCore.Http.HttpResults;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository;
using v1.Repository.IRepository;
using v1.Services.IService;

namespace v1.Services
{
    public class CommonCollectionService : ICommonCollectionServiceInterface
    {
        private readonly ICommonCollectionInterface _repository;

        public CommonCollectionService(ICommonCollectionInterface repository)
        {
            _repository = repository;
        }

        public async Task<CommonCollectionResponseDto> CreateAsync(CreateCommonCollectionDto dto, string createdBy)
        {
            var commonCollection = new CommonCollection
            {
                Id = Guid.NewGuid(),
                MerchantName = dto.MerchantName,
                InvoiceNumber = dto.InvoiceNumber,
                CollectionDate = dto.CollectionDate,
                CollectedAmount = dto.CollectedAmount,
                BankName = dto.BankName,
                CheckNumber = dto.CheckNumber,
                ClearingBranch = dto.ClearingBranch,
                CheckSubmissionDate = dto.CheckSubmissionDate,
                CollectionOfficer = dto.CollectionOfficer,
                Region = dto.Region,
                Memo = dto.Memo,
                FileAttachment = dto.FileAttachment,

                // TableOperationDetails
                Status = 1,
                CreateBy = createdBy,
                CreateAt = DateTime.UtcNow.AddHours(6),
                UpdateBy = createdBy,
                UpdateAt = DateTime.UtcNow.AddHours(6),
                IsDeleted = false,

                BillDetails = dto.BillDetails.Select(bd => new BillDetails
                {
                    Id = Guid.NewGuid(),
                    BillingYear = bd.BillingYear,
                    BillingMonth = bd.BillingMonth,
                    BillingAmount = bd.BillingAmount
                }).ToList()
            };

            var created = await _repository.CreateAsync(commonCollection);
            return MapToResponseDto(created);
        }

        public async Task<List<CommonCollectionResponseDto>> GetAllAsync()
        {
            var collections = await _repository.GetAllAsync();
            return collections.Select(MapToResponseDto).Where(data=>data.IsDeleted is false).ToList();
        }

        public async Task<CommonCollectionResponseDto?> GetByIdAsync(Guid id)
        {
            var collection = await _repository.GetByIdAsync(id);
            return collection != null ? MapToResponseDto(collection) : null;
        }

        public async Task<bool> SoftDeleteAsync(Guid id, string deletedBy)
        {
            return await _repository.SoftDeleteAsync(id, deletedBy);
        }

        private CommonCollectionResponseDto MapToResponseDto(CommonCollection collection)
        {
            return new CommonCollectionResponseDto
            {
                Id = collection.Id,
                MerchantName = collection.MerchantName,
                InvoiceNumber = collection.InvoiceNumber,
                CollectionDate = collection.CollectionDate,
                CollectedAmount = collection.CollectedAmount,
                BankName = collection.BankName,
                CheckNumber = collection.CheckNumber,
                ClearingBranch = collection.ClearingBranch,
                CheckSubmissionDate = collection.CheckSubmissionDate,
                CollectionOfficer = collection.CollectionOfficer,
                Region = collection.Region,
                Memo = collection.Memo,
                FileAttachment = collection.FileAttachment,

                // TableOperationDetails
                Status = collection.Status,
                CreateBy = collection.CreateBy,
                CreateAt = collection.CreateAt,
                UpdateBy = collection.UpdateBy,
                UpdateAt = collection.UpdateAt,
                DeleteBy = collection.DeleteBy,
                DeleteAt = collection.DeleteAt,
                IsDeleted = collection.IsDeleted,

                BillDetails = collection.BillDetails.Select(bd => new BillDetailsDto
                {
                    BillingYear = bd.BillingYear,
                    BillingMonth = bd.BillingMonth,
                    BillingAmount = bd.BillingAmount
                }).ToList()
            };
        }
    }
}
