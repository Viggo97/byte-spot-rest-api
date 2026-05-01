namespace ByteSpot.Application.Dto;

public sealed record WorkModeWithTranslationsDto(int Id, string Name, IEnumerable<TranslationDto> Translations);