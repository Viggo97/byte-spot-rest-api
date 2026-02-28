namespace ByteSpot.Application.Dto;

public sealed record OfferDto(
    Guid Id,
    string Title,
    string Company,
    int? SalaryMin,
    int? SalaryMax,
    int? SalaryFixed,
    List<string> Locations,
    List<string> Technologies);
