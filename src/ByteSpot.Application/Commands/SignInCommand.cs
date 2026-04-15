using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands;

public record SignInCommand(string Email, string Password) : ICommand;