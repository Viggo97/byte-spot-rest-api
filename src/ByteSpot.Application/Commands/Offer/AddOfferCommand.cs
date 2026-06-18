using ByteSpot.Application.Abstractions;
using ByteSpot.Domain.Enums;
using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Application.Commands.Offer;

public record AddOfferCommand(
    Identifier Id,
    string Title,
    IEnumerable<int> WorkModes,
    IEnumerable<string> Locations,
    IEnumerable<string> ExperienceLevels,
    IEnumerable<string> Technologies,
    IEnumerable<Contract> Contracts,
    string Description
) : ICommand;

public record Contract(
    int EmploymentTypeId,
    int? SalaryMin,
    int? SalaryMax,
    int? SalaryFixed,
    SalaryType SalaryType,
    CurrencyCode CurrencyCode,
    BillingUnit BillingUnit
);
    