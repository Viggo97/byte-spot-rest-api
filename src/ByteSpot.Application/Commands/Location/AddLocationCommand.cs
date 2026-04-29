using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Location;

public record AddLocationCommand(string Name) : ICommand;