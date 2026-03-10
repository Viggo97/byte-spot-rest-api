using ByteSpot.Domain.Entities.Translations;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class WorkMode
{
    public int Id { get; private set; }
    public string Value { get; private set; }
    public ICollection<WorkModeTranslation> Translations { get; private set; } = new List<WorkModeTranslation>();
    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();
    
    private WorkMode(int id, string value)
    {
        Id = id;
        Value = value;
    }

    public static WorkMode Create(int id, string value) => new(id, value);
}