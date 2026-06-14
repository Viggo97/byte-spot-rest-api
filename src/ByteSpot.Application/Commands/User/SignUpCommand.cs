using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record SignUpCommand(string Email, string Password, string Role, string FirstName, string LastName) : ICommand;