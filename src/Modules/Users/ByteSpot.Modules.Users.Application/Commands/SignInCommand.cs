using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record SignInCommand(string Email, string Password) : ICommand;