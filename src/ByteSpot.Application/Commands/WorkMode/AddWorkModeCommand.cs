using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed record AddWorkModeCommand(string Value, List<TranslationDictionary> Translations) : ICommand;