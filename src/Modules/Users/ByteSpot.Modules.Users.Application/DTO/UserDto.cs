namespace ByteSpot.Modules.Users.Application.DTO;

public sealed record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Role,
    string? CompanyId
);