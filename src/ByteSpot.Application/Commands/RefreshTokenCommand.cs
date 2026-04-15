using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands;

public record RefreshTokenCommand(string? RefreshToken) : ICommand;