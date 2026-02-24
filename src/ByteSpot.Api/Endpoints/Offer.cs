namespace ByteSpot.Api.Endpoints;

public static class Offer
{
    private const string Route = "/api/offers";
    
    public static WebApplication MapOfferEndpoints(this WebApplication app)
    {
        app.MapGet(Route, async (HttpContext context) =>
        {
            return Results.Ok("First offer");
        });
        
        return app;
    }
}