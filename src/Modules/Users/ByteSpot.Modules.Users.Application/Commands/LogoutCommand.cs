using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record LogoutCommand(string? RefreshToken) : ICommand;