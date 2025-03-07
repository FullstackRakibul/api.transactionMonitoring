using v1.DbContexts.Models;
using v1.DTOs;
using v1.Repository.IRepository;
using v1.Services.IService;

namespace v1.Services
{
    public class CardTypeService : ICardTypeServiceInterface
    {
        private readonly ICardTypeInterface _cardTypeRepository;

        public CardTypeService(ICardTypeInterface cardTypeRepository)
        {
            _cardTypeRepository = cardTypeRepository;
        }

        public async Task<CardTypeDto> CreateCardTypeAsync(CardTypeDto dto, string createdBy)
        {
            // Check if a CardType with the same name already exists.
            var existing = await _cardTypeRepository.GetByNameAsync(dto.CardTypeName);
            if (existing != null)
            {
                throw new Exception("Card Type already exists.");
            }

            var entity = new CardType
            {
                Id = Guid.NewGuid(),
                CardTypeName = dto.CardTypeName,
                Details = dto.Details,
            };

            await _cardTypeRepository.AddAsync(entity);

            // Map entity back to DTO.
            return new CardTypeDto
            {
                Id = entity.Id,
                CardTypeName = entity.CardTypeName,
                Details = entity.Details
            };
        }

        public async Task<IEnumerable<CardTypeDto>> GetAllCardTypesAsync()
        {
            var types = await _cardTypeRepository.GetAllAsync();
            return types.Select(t => new CardTypeDto
            {
                Id = t.Id,
                CardTypeName = t.CardTypeName,
                Details = t.Details
            });
        }
    }
}