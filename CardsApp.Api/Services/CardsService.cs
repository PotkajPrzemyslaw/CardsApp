using CardsApp.Api.Dtos;
using CardsApp.Api.Repositories.Interfaces;
using CardsApp.Api.Services.Interfaces;
using CardsApp.Data.Entities;

namespace CardsApp.Api.Services;

public class CardsService : ICardsService
{
    private readonly ICardsRepository _repo;

    private readonly Func<Card, CardDto> _convertToDto = e => new CardDto
    {
        Id = e.Id,
        MaxUserAmount = e.MaxUserAmount,
        Name = e.Name,
    };

    private readonly Func<CreateCardDto, Card> _convertFromDto = e => new Card
    {
        MaxUserAmount = e.MaxUserAmount,
        Name = e.Name,
    };

    public CardsService(ICardsRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<CardDto>> GetCards()
    {
        return (await _repo.GetCards())
            .Select(x => _convertToDto(x));
    }

    public async Task<IEnumerable<CardDto>> GetCards(int page, int pageSize)
    {
        return (await _repo.GetCards(page, pageSize))
            .Select(x => _convertToDto(x));
    }

    public async Task<CardDto> GetSingleCard(int id)
    {
        return _convertToDto(await _repo.GetSingleCard(id));
    }

    public async Task DeleteCard(int id)
    {
        await _repo.DeleteCard(id);
    }

    public async Task CreateCard(CreateCardDto card)
    {
        await _repo.CreateCard(_convertFromDto(card));
    }
}