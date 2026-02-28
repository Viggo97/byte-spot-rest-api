using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;
using ByteSpot.Application.Queries;

namespace ByteSpot.Api.Endpoints;

public static class OfferEndpoints
{
    private const string Route = "/api/offers";
    
    public static WebApplication MapOfferEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (IQueryHandler<GetOffersQuery, IEnumerable<OfferDto>> handler) =>
        {
            var offers = await handler.HandleAsync(new GetOffersQuery());
            return Results.Ok(offers);
        });
        
        return app;
    }
}