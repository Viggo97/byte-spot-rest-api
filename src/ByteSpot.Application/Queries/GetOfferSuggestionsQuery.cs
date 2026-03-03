using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries;

public record GetOfferSuggestionsQuery(string? SearchPhrase) 
    : IQuery<List<OfferSuggestionDto>>, IQuery<OfferSuggestionDto>;