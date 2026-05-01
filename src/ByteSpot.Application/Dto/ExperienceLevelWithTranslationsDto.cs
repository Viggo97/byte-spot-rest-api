namespace ByteSpot.Application.Dto;

public sealed record ExperienceLevelWithTranslationsDto(int Id, string Name, IEnumerable<TranslationDto> Translations);
