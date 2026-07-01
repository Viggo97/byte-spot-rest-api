using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName) : ICommand;