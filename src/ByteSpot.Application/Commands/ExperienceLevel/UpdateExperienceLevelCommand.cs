using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed record UpdateExperienceLevelCommand(int Id, string? Value, List<TranslationDictionary> Translations) : ICommand;
