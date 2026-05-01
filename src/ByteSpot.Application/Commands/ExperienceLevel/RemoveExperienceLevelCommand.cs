using ByteSpot.Application.Abstractions;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed record RemoveExperienceLevelCommand(int Id): ICommand;
