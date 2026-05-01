namespace ByteSpot.Application.Dto;

public sealed record EmploymentTypeWithTranslationsDto(int Id, string Name, IEnumerable<TranslationDto> Translations);
