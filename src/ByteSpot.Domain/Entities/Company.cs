using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Company
{
    public Identifier Id { get; private set; }
    public Name Name { get; private set; }
    public ICollection<Offer> Offers { get; private set; } = new List<Offer>();
    public ICollection<User> Users { get; private set; } = new List<User>();

    private Company(Identifier id, Name name)
    {
        Id = id;
        Name = name;
    }

    public static Company Create(Identifier id, Name name) => new(id, name);

    public void AddUsers(List<User> users)
    {
        foreach (var user in users)
        {
            Users.Add(user);
        }
    }
}