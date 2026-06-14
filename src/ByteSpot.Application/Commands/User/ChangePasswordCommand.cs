using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.User;

public record ChangePasswordCommand(Guid Id,  string OldPassword, string NewPassword) : ICommand;