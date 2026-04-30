using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.Technology;

public record AddTechnologyCommand(string Name, string IconCode) : ICommand;
