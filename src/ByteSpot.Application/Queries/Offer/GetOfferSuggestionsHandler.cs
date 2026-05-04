using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Domain.Repositories;

namespace ByteSpot.Application.Queries.Offer;

internal sealed class GetOfferSuggestionsHandler
    : IQueryHandler<GetOfferSuggestionsQuery, List<OfferSuggestionDto>>
{
    private readonly ISuggestionRepository _suggestionRepository;

    public GetOfferSuggestionsHandler(ISuggestionRepository suggestionRepository)
    {
        _suggestionRepository = suggestionRepository;
    }
    
    public async Task< List<OfferSuggestionDto>> HandleAsync(GetOfferSuggestionsQuery query)
    {
        if (query.SearchPhrase is null)
        {
            return [];
        }
        
        var phrase = query.SearchPhrase.ToLower();

        var locations = await _suggestionRepository
            .GetLocationsAsync(phrase);
        var locationsDto = locations.Select(location => new OfferSuggestionDto(location.Id, location.Name, OfferSuggestionCategory.Location));
            

        var technologies = await _suggestionRepository
            .GetTechnologiesAsync(phrase);
        var technologyDto = technologies.Select(technology => new OfferSuggestionDto(technology.Id, technology.Name, OfferSuggestionCategory.Technology));
        
        var companies = await _suggestionRepository
            .GetCompaniesAsync(phrase);
        var companiesDto = companies.Select(company => new OfferSuggestionDto(company.Id, company.Name, OfferSuggestionCategory.Company));

        var titles = await _suggestionRepository
            .GetOffersAsync(phrase);
        var titlesDto = titles.Select(title => new OfferSuggestionDto(title.Id, title.Title, OfferSuggestionCategory.Title));
        
        return locationsDto.Concat(technologyDto).Concat(companiesDto).Concat(titlesDto).ToList();
    }
}