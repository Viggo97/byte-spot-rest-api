using ByteSpot.Domain.Entities.Translations;

namespace ByteSpot.Domain.Entities;

public class EmploymentType
{
    public int Id { get; private set; }
    public string Value { get; private set; }

    public ICollection<EmploymentTypeTranslation> Translations { get; private set; } =
        new List<EmploymentTypeTranslation>();

    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();

    private EmploymentType(string value)
    {
        Value = value;
    }

    private EmploymentType(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public static EmploymentType Create(string value) => new(value);

    public static EmploymentType Create(int id, string value) => new(id, value);

    public void ChangeValue(string value)
    {
        Value = value;
    }

    public void AddTranslation(EmploymentTypeTranslation translation)
    {
        Translations.Add(translation);
    }
}