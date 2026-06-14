using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record RefreshTokenCommand(string? RefreshToken) : ICommand;