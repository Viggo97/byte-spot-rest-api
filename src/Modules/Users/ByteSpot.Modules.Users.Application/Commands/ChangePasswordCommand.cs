using ByteSpot.Shared.Abstractions.Commands;

namespace ByteSpot.Modules.Users.Application.Commands;

public record ChangePasswordCommand(Guid Id,  string OldPassword, string NewPassword) : ICommand;