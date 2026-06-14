using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record SignInCommand(string Email, string Password) : ICommand;