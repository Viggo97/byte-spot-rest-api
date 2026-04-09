namespace ByteSpot.Application.Dto;

public sealed record OfferDetailsDto(
    Guid Id,
    string Title,
    CompanyMinimalDto Company,
    long ValidFrom,
    long ValidTo,
    List<SalaryDto> Salaries,
    List<string> Locations,
    List<string> Technologies,
    List<string> WorkModes,
    List<string> ExperienceLevels,
    string Description
);