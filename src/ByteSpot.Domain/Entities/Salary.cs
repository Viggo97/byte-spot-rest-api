using ByteSpot.Domain.ValueObjects.Offer;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class Salary
{
    public Identifier Id { get; private set; }
    public Identifier OfferId { get; private set; }
    public Offer Offer { get; private set; } = default!;
    public int EmploymentTypeId { get; private set; }
    public EmploymentType EmploymentType { get; private set; } = default!;
    public int? Min { get; private set; }
    public int? Max { get; private set; }
    public int? Fixed { get; private set; }
    public Currency Currency { get; private set; }

    private Salary(Identifier id, Identifier offerId, int employmentTypeId, int? min, int? max, int? @fixed, Currency currency)
    {
        Id = id;
        OfferId = offerId;
        EmploymentTypeId = employmentTypeId;
        Min = min;
        Max = max;
        Fixed = @fixed;
        Currency = currency;
    }

    public static Salary Create(Identifier id, Identifier offerId, int employmentTypeId,
        int? min, int? max, int? @fixed, Currency currency) 
        => new (id, offerId, employmentTypeId,  min,  max, @fixed, currency);
}