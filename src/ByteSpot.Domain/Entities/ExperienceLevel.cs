using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class ExperienceLevel
{
    public int Id { get; private set; }
    public string Value { get; private set; }
    public ICollection<ExperienceLevelTranslation> Translations { get; private set; } =
        new List<ExperienceLevelTranslation>();
    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();

    private ExperienceLevel(string value)
    {
        Value = value;
    }
    
    private ExperienceLevel(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public static ExperienceLevel Create(string value) => new(value);
    
    public static ExperienceLevel Create(int id, string value) => new(id, value);

    public void ChangeValue(string value)
    {
        Value = value;
    }

    public void AddTranslation(ExperienceLevelTranslation translation)
    {
        Translations.Add(translation);
    }
}