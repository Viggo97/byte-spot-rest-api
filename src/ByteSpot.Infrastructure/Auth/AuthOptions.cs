namespace ByteSpot.Infrastructure.Auth;

public sealed class AuthOptions
{
    public const string AuthOptionsKey = "Authentication";
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string SigningKey { get; set; } = default!;
    public TimeSpan Expiry { get; set; }
    public TimeSpan ExpiryRefreshToken { get; set; }
}