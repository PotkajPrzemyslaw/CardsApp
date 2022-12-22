using CardsApp.Data.Entities.Base;

namespace CardsApp.Data.Entities;

public class Card : BaseEntity
{
    public int MaxUserAmount { get; set; } = 10;
    public string Name { get; set; }
}