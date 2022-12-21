using CardsApp.Api.Dtos;

namespace CardsApp.Api.Services.Interfaces;

public interface ICardsService
{
    Task<IEnumerable<CardDto>> GetCards();
    Task<IEnumerable<CardDto>> GetCards(int page, int pageSize);
    Task<CardDto> GetSingleCard(int id);
    Task DeleteCard(int id);
    Task CreateCard(CreateCardDto card);
}