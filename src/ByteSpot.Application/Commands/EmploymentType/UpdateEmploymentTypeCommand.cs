using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed record UpdateEmploymentTypeCommand(int Id, string? Value, List<TranslationDictionary> Translations) : ICommand;
