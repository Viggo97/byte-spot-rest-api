using ByteSpot.Domain.Enums;

namespace ByteSpot.Application.Dto;

public sealed record TranslationDto(Guid Id, string Value, LanguageCode LanguageCode);