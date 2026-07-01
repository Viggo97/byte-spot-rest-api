using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record SignUpCommand(string Email, string Password, string Role, string FirstName, string LastName) : ICommand;