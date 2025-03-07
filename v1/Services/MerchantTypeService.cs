using Microsoft.AspNetCore.SignalR;
using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;
using v1.Services.IService;

namespace v1.Services;

public class MerchantTypeService :IMerchantTypeServiceInterface
{
    private readonly IMerchantTypeInterface _merchantTypeRepository;

    public MerchantTypeService(IMerchantTypeInterface merchantTypeRepository)
    {
        _merchantTypeRepository = merchantTypeRepository;
    }

    public async Task<MerchantTypeDto> CreateMerchantTypeAsync(MerchantTypeDto dto, string createdBy)
    {
        // Check if a MerchantType with the same name already exists.
        var existing = await _merchantTypeRepository.GetByNameAsync(dto.Name);
        if (existing != null)
        {
            throw new Exception("Merchant Type already exists.");
        }

        var entity = new MerchantType()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
        };

        await _merchantTypeRepository.AddAsync(entity);

        // Map entity back to DTO.
        return new MerchantTypeDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }

    public async Task<IEnumerable<MerchantTypeDto>> GetAllMerchantTypesAsync()
    {
        var types = await _merchantTypeRepository.GetAllAsync();
        return types.Select(t => new MerchantTypeDto
        {
            Id = t.Id,
            Name = t.Name
        });
    }

    public async Task<Guid> GetMerchantTypeByIdAsync(Guid id)
    {
        dynamic guid =  await _merchantTypeRepository.GetByIdAsync(id);
        return guid;
    }
    
}