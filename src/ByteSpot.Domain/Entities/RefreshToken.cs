using ByteSpot.Domain.ValueObjects.Shared;

namespace ByteSpot.Domain.Entities;

public class RefreshToken
{
    public Identifier Id { get; private set; }
    public string Token { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public Identifier UserId { get; private set; } = default!;
    public User User { get; private set; } = default!;

    private RefreshToken(Identifier id, string token, DateTimeOffset expiresAt)
    {
        Id = id;
        Token = token;
        ExpiresAt = expiresAt;
    }

    public static RefreshToken Create(Identifier id, string token, DateTimeOffset expiresAt) 
        => new (id, token, expiresAt);
}