using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class EmploymentType
{
    public int Id { get; private set; }
    public string Value { get; private set; }

    public ICollection<EmploymentTypeTranslation> Translations { get; private set; } =
        new List<EmploymentTypeTranslation>();

    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();

    private EmploymentType(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public static EmploymentType Create(int id, string value) => new(id, value);
}