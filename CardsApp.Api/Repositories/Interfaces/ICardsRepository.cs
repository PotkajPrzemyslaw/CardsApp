using CardsApp.Data.Entities;

namespace CardsApp.Api.Repositories.Interfaces;

public interface ICardsRepository
{
    Task CreateCard(Card card);
    Task DeleteCard(int id);
    Task<IEnumerable<Card>> GetCards();
    Task<IEnumerable<Card>> GetCards(int page, int pageSize);
    Task<Card> GetSingleCard(int id);
}