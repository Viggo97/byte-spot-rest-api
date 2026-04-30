using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Technology;

public record RemoveTechnologyCommand(Guid Id) : ICommand;
