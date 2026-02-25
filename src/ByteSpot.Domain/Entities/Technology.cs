using ByteSpot.Domain.ValueObjects.Shared;
using ByteSpot.Domain.ValueObjects.Technology;

namespace ByteSpot.Domain.Entities;

public class Technology
{
    public Identifier Id { get; private set; }
    public Name Name { get; private set; }
    public IconCode IconCode { get; private set; }
    
    public ICollection<Offer> Offers = new List<Offer>();

    private Technology(Identifier id, Name name, IconCode iconCode)
    {
        Id = id;
        Name = name;
        IconCode = iconCode;
    }
    
    public static Technology Create(Identifier id, Name name, IconCode iconCode) => new(id, name, iconCode);
}