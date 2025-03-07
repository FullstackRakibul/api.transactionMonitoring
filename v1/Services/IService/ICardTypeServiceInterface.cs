using v1.DTOs;

namespace v1.Services.IService
{
    public interface ICardTypeServiceInterface
    {
        Task<CardTypeDto> CreateCardTypeAsync(CardTypeDto dto, string createdBy);
        Task<IEnumerable<CardTypeDto>> GetAllCardTypesAsync();
        
    }
}