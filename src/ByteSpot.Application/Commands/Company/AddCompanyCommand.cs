using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Company;

public sealed record AddCompanyCommand(
    string Email,
    string Password,
    string UserFirstName,
    string UserLastName,
    string Id,
    string Name
) : ICommand;