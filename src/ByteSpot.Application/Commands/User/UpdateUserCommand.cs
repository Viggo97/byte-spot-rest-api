using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record UpdateUserCommand(Guid Id, string FirstName, string LastName) : ICommand;