using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;

namespace ByteSpot.Application.Commands.EmploymentType;

public sealed record AddEmploymentTypeCommand(string Value, List<TranslationDictionary> Translations) : ICommand;
