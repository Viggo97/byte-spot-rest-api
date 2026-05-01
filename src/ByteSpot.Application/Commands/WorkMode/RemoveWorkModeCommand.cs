using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed record RemoveWorkModeCommand(int Id): ICommand;