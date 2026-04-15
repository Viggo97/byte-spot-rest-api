namespace ByteSpot.Application.Dto;

public sealed record JwtDto
{
    public string AccessToken { get; init; } = default!;
}