using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record RefreshTokenCommand(string? RefreshToken) : ICommand;