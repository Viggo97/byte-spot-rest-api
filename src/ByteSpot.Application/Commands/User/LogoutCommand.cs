using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record LogoutCommand(string? RefreshToken) : ICommand;