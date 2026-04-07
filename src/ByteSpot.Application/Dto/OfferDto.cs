namespace ByteSpot.Application.Dto;

public sealed record OfferDto(
    Guid Id,
    string Title,
    string Company,
    List<SalaryDto> Salaries,
    List<string> Locations,
    List<string> Technologies);