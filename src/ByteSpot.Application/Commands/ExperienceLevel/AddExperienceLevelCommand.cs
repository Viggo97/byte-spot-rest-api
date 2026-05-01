using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.ExperienceLevel;

public sealed record AddExperienceLevelCommand(string Value, List<TranslationDictionary> Translations) : ICommand;
