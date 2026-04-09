using ByteSpot.Domain.Enums;

namespace ByteSpot.Application.Dto;

public sealed record SalaryDto(    
    int? Min,
    int? Max,
    int? Fixed,
    SalaryType Type,
    CurrencyCode CurrencyCode,
    BillingUnit BillingUnit,
    EmploymentTypeDto EmploymentType);