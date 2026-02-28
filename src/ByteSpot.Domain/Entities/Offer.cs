using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Offer
{
    public Identifier Id { get; private set; }
    public Title Title { get; private set; }
    public Identifier CompanyId { get; private set; }
    public Company Company { get; private set; }
    public Salary Salary { get; private set; }
    public ICollection<Location> Locations { get; private set; } = new List<Location>();
    public ICollection<Technology> Technologies { get; private set; } = new List<Technology>();
    
    private Offer() {}
    
    private Offer(Identifier id, Title title, Salary salary, Identifier companyId)
    {
        Id = id;
        Title = title;
        CompanyId = companyId;
        Salary = salary;
    }

    public static Offer Create(Identifier id, Title title, Salary salary, Identifier companyId)
        => new(id, title, salary, companyId);

    public void AddLocation(Location location)
    {
        Locations.Add(location);
    }
    
    public void AddTechnology(Technology technology)
    {
        Technologies.Add(technology);
    }
}