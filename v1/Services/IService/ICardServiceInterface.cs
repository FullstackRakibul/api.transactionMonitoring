using v1.DTOs;

namespace v1.Services.IService;

public interface ICardServiceInterface
{
    Task<Guid> CreateCardDetailsAsync(CardDto cardDto);
}