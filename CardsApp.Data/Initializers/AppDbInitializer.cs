using CardsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardsApp.Data.Initializers;

public static class AppDbInitializer
{
    public static async Task SeedAsync(AppDbContext db)
    {
        // Ta metoda sprawdza czy baza jest utworzona i jesli nie to ja utworzyc - przezornie ;)
        await db.Database.EnsureCreatedAsync();

        // Dodajemy testowe obiekty
        await SeedData(db);

        // Zapisujemy zmiany
        await db.SaveChangesAsync();
    }

    private static async Task SeedData(DbContext db)
    {
        await db.AddRangeAsync(new List<Card>
        {
            new() {Name = "Card1", MaxUserAmount = 1000},
            new() {Name = "Card2", MaxUserAmount = 2000},
            new() {Name = "Card3", MaxUserAmount = 500},
            new() {Name = "Card4", MaxUserAmount = 100},
            new() {Name = "Card5", MaxUserAmount = 1500},
        });
    }
}