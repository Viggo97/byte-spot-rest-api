using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Location;

public record RemoveLocationCommand(Guid Id) : ICommand;