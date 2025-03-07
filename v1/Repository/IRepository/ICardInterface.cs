using v1.DbContexts.Models;

namespace v1.Repository.IRepository;

public interface ICardInterface
{
    //Task AddCardsAsync(CardDetails cards);
    Task AddCardsAsync(List<CardDetails> cards);
}