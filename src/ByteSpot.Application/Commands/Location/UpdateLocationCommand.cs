using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Location;

public record UpdateLocationCommand(Guid Id, string Name) : ICommand;