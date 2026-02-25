using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Offer
{
    public Identifier Id { get; private set; }
    public Title Title { get; private set; }
    public Company Company { get; private set; }
    public Salary? Salary { get; private set; }
    public ICollection<Location> Locations = new List<Location>();
    public ICollection<Technology> Technologies = new List<Technology>();
    
    private Offer(Identifier id, Title title, Company company, Salary? salary)
    {
        Id = id;
        Title = title;
        Company = company;
        Salary = salary;
    }

    public static Offer Create(Identifier id, Title title, Company company, Salary? salary)
        => new(id, title, company, salary);
}