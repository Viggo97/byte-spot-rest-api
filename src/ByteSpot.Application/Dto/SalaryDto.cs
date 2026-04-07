namespace ByteSpot.Application.Dto;

public sealed record SalaryDto(    
    int? SalaryMin,
    int? SalaryMax,
    int? SalaryFixed);