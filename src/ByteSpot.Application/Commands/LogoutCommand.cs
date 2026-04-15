using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands;

public record LogoutCommand(string? RefreshToken) : ICommand;