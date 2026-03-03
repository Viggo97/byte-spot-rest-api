using ByteSpot.Application.Common;

namespace ByteSpot.Application.Dto;

public sealed record OfferSuggestionDto(Guid Id, string Value, OfferSuggestionCategory Category);