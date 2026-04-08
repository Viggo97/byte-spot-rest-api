using ByteSpot.Domain.Enums;
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
    public SalaryType Type { get; private set; }
    public int? Min { get; private set; }
    public int? Max { get; private set; }
    public int? Fixed { get; private set; }
    public CurrencyCode CurrencyCode { get; private set; }
    public BillingUnit BillingUnit { get; private set; }

    private Salary(Identifier id, Identifier offerId, int employmentTypeId, SalaryType type, int? min, int? max, int? @fixed,
        CurrencyCode currencyCode, BillingUnit billingUnit)
    {
        Id = id;
        OfferId = offerId;
        EmploymentTypeId = employmentTypeId;
        Type = type;
        Min = min;
        Max = max;
        Fixed = @fixed;
        CurrencyCode = currencyCode;
        BillingUnit = billingUnit;
    }

    public static Salary Create(Identifier id, Identifier offerId, int employmentTypeId, SalaryType type, int? min, int? max, int? @fixed,
        CurrencyCode currencyCode, BillingUnit billingUnit) 
        => new (id, offerId, employmentTypeId, type,  min,  max, @fixed, currencyCode, billingUnit);
}