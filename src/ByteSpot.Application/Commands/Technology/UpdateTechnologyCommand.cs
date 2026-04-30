using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Technology;

public record UpdateTechnologyCommand(Guid Id, string Name, string IconCode) : ICommand;
