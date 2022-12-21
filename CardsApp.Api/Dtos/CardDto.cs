using CardsApp.Api.Dtos.Base;

namespace CardsApp.Api.Dtos;

public class CardDto : BaseDto
{
    public int MaxUserAmount { get; set; }
    public string Name { get; set; }
}