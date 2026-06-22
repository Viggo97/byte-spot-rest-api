namespace ByteSpot.Application.Dto;

public sealed record UserDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Role
);