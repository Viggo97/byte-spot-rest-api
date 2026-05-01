using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.WorkMode;

public sealed record UpdateWorkModeCommand(int Id, string? Value, List<TranslationDictionary> Translations) : ICommand;