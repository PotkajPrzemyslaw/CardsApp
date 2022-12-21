using CardsApp.Data.Entities.Base;

namespace CardsApp.Data.Entities;

// Pobieramy z BaseEntity Id i CreationDateTime oraz dodajemy nowe pola
public class Card : BaseEntity
{
    public int MaxUserAmount { get; set; } = 10;
    public string Name { get; set; }
}