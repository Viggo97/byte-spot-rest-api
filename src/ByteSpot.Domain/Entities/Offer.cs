using ByteSpot.Domain.Enums;
using ByteSpot.Domain.Exceptions.Offer;
using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Offer
{
    public Identifier Id { get; private set; }
    public Title Title { get; private set; }
    public Identifier CompanyId { get; private set; }
    public Company Company { get; private set; } = default!;
    public DateTimeOffset CreatedAt { get; private set; }
    public DateTimeOffset ExpiresAt { get; private set; }
    public ICollection<Salary> Salaries { get; private set; } = new List<Salary>();
    public int SalaryMinComputed { get; private set; } = default;
    public int SalaryMaxComputed { get; private set; } = default;
    public ICollection<Location> Locations { get; private set; } = new List<Location>();
    public ICollection<Technology> Technologies { get; private set; } = new List<Technology>();
    public ICollection<WorkMode> WorkModes { get; private set; } = new List<WorkMode>();
    public ICollection<ExperienceLevel> ExperienceLevels { get; private set; } = new List<ExperienceLevel>();
    public ICollection<EmploymentType> EmploymentTypes { get; private set; } = new List<EmploymentType>();

    private Offer()
    {
    }

    private Offer(Identifier id, Title title, Identifier companyId, DateTimeOffset createdAt, DateTimeOffset expiresAt)
    {
        Id = id;
        Title = title;
        CompanyId = companyId;
        CreatedAt = createdAt;
        ExpiresAt = expiresAt;
    }

    public static Offer Create(Identifier id, Title title, Identifier companyId, DateTimeOffset createdAt,
        DateTimeOffset expiresAt)
        => new(id, title, companyId, createdAt, expiresAt);

    public void AddSalary(Salary salary)
    {
        Salaries.Add(salary);
        CalculateComputedSalary(Salaries, out var salaryMinComputed, out var salaryMaxComputed);
        SalaryMinComputed = salaryMinComputed;
        SalaryMaxComputed = salaryMaxComputed;
    }

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

    private static void CalculateComputedSalary(ICollection<Salary> salaries, out int min, out int max)
    {
        min = int.MaxValue;
        max = 0;
            
        foreach (var salary in salaries)
        {
            var minValue = salary.Fixed ?? salary.Min ?? throw new SalaryNotProvidedException();
            var maxValue = salary.Fixed ?? salary.Max ?? throw new SalaryNotProvidedException();
            var currentMin = CalculateSalary(minValue, salary.BillingUnit, salary.CurrencyCode);
            var currentMax = CalculateSalary(maxValue, salary.BillingUnit, salary.CurrencyCode);

            if (currentMin < min)
            {
                min = currentMin;
            }
            
            if (currentMax > max)
            {
                max = currentMax;
            }
        }
    }

    private static int CalculateSalary(int value, BillingUnit billingUnit, CurrencyCode currencyCode)
    {
        var billingUnitLessSalary = billingUnit switch
        {
            // Assumption: 1 month = 20 days = 160 hours (1 day = 8 hours)
            BillingUnit.HOUR => 8 * 20,
            BillingUnit.DAY => 20,
            _ => 1
        };

        var currencyLessSalary = currencyCode switch
            {
                CurrencyCode.USD => 3.7,
                CurrencyCode.EUR => 4.2,
                _ => 1
            };

        return (int)Math.Round(value *  billingUnitLessSalary * currencyLessSalary);
    }
}