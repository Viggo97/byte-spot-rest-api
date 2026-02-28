using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Company
{
    public Identifier Id { get; private set; }
    public Name Name { get; private set; }
    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();

    private Company(Identifier id, Name name)
    {
        Id = id;
        Name = name;
    }

    public static Company Create(Identifier id, Name name) => new(id, name);
}