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
    public DateTimeOffset CreatedAt { get; private set; }
    public ICollection<Location> Locations { get; private set; } = new List<Location>();
    public ICollection<Technology> Technologies { get; private set; } = new List<Technology>();
    public ICollection<WorkMode> WorkModes { get; private set; } = new List<WorkMode>();
    public ICollection<ExperienceLevel> ExperienceLevels { get; private set; } = new List<ExperienceLevel>();
    public ICollection<EmploymentType> EmploymentTypes { get; private set; } = new List<EmploymentType>();
    
    private Offer() {}
    
    private Offer(Identifier id, Title title, Salary salary, Identifier companyId, DateTimeOffset createdAt)
    {
        Id = id;
        Title = title;
        CompanyId = companyId;
        Salary = salary;
        CreatedAt = createdAt;
    }

    public static Offer Create(Identifier id, Title title, Salary salary, Identifier companyId, DateTimeOffset createdAt)
        => new(id, title, salary, companyId, createdAt);

    public void AddLocation(Location location)
    {
        Locations.Add(location);
    }
    
    public void AddTechnology(Technology technology)
    {
        Technologies.Add(technology);
    }

    public void AddWorkMode(WorkMode workMode)
    {
        WorkModes.Add(workMode);
    }
    
    public void AddExperienceLevel(ExperienceLevel experienceLevel)
    {
        ExperienceLevels.Add(experienceLevel);
    }

    public void AddEmploymentType(EmploymentType employmentType)
    {
        EmploymentTypes.Add(employmentType);
    }
}