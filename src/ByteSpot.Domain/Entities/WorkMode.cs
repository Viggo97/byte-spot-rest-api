using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class WorkMode
{
    public int Id { get; private set; }
    public Name Name { get; private set; }
    
    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();
    
    private WorkMode(int id, Name name)
    {
        Id = id;
        Name = name;
    }

    public static WorkMode Create(int id, Name name) => new(id, name);
}