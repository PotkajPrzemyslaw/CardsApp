namespace CardsApp.Data.Entities.Base;

// Dodalem BaseEntity bo kazdy obiekt bedzie mial Id wiec mozemy dziedziczyc bez powielania kodu
// Dodalem tez CreationDateTime ktory nie jest nigdzie uzyty, ale moim zdaniem jest to spoko dodatkowy feature
public class BaseEntity
{
    public int Id { get; set; }
}