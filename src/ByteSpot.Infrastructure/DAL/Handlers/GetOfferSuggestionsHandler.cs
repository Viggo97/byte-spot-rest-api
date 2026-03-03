using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Common;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;
using ByteSpot.Infrastructure.DAL.Database;
using Microsoft.EntityFrameworkCore;

namespace ByteSpot.Infrastructure.DAL.Handlers;

internal sealed class GetOfferSuggestionsHandler(ByteSpotDbContext dbContext) 
    : IQueryHandler<GetOfferSuggestionsQuery, List<OfferSuggestionDto>>
{
    public async Task< List<OfferSuggestionDto>> HandleAsync(GetOfferSuggestionsQuery query)
    {
        if (query.SearchPhrase is null)
        {
            return [];
        }
        
        var phrase = query.SearchPhrase.ToLower();
        var locations = await dbContext.Locations
            .Where(location => ((string)location.Name).ToLower().Contains(phrase))
            .OrderBy(location => location.Name)
            .Take(3)
            .Select(location => new OfferSuggestionDto(location.Id, location.Name, OfferSuggestionCategory.Location))
            .ToListAsync();

        var technologies = await dbContext.Technologies
            .Where(technology => ((string)technology.Name).ToLower().Contains(phrase))
            .OrderBy(technology => technology.Name)
            .Take(3)
            .Select(technology => new OfferSuggestionDto(technology.Id, technology.Name, OfferSuggestionCategory.Technology))
            .ToListAsync();
        
        var companies = await dbContext.Companies
            .Where(company => ((string)company.Name).ToLower().Contains(phrase))
            .OrderBy(company => company.Name)
            .Take(3)
            .Select(company => new OfferSuggestionDto(company.Id, company.Name, OfferSuggestionCategory.Company))
            .ToListAsync();
        
        var titles = await dbContext.Offers
            .Where(offer => ((string)offer.Title).ToLower().Contains(phrase))
            .OrderBy(offer => offer.Title)
            .Take(3)
            .Select(offer => new OfferSuggestionDto(offer.Id, offer.Title.Value, OfferSuggestionCategory.Title))
            .ToListAsync();
        
        return locations.Concat(technologies).Concat(companies).Concat(titles).ToList();
    }
}