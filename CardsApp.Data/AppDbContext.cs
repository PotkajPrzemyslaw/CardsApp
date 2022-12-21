using CardsApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardsApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}