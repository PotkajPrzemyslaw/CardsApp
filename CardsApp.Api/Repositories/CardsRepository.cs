using CardsApp.Api.Extensions;
using CardsApp.Api.Repositories.Interfaces;
using CardsApp.Data;
using CardsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardsApp.Api.Repositories;

public class CardsRepository : ICardsRepository
{
    private readonly AppDbContext _db;

    public CardsRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task CreateCard(Card card)
    {
        await _db.AddAsync(card);

        await _db.SaveChangesAsync();
    }

    public async Task DeleteCard(int id)
    {
        var card = await _db.Cards
            .FirstOrDefaultAsync(x => x.Id == id);

        if (card == null)
            throw new Exception("Card has not been found in the database");

        _db.Remove(card);

        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Card>> GetCards()
    {
        return await _db.Cards
            .ToListAsync();
    }

    public async Task<IEnumerable<Card>> GetCards(int page, int pageSize)
    {
        return await _db.Cards
            .AsQueryable()
            .Paged(page, pageSize)
            .ToListAsync();
    }

    public async Task<Card> GetSingleCard(int id)
    {
        var card = await _db.Cards
            .FirstOrDefaultAsync(x => x.Id == id);

        if (card == null)
            throw new Exception("Card has not been found in the database");

        return card;
    }
}