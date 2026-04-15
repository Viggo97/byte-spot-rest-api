namespace ByteSpot.Domain.ValueObjects.User;

public sealed record AuthCookieKey
{
    private const string AccessTokenKey = "AccessToken";
    private const string RefreshTokenKey = "RefreshToken";
    
    public string Value { get; }
    
    private AuthCookieKey(string key)
    {
        Value = key;
    }

    public static AuthCookieKey AccessToken => new (AccessTokenKey);
    public static AuthCookieKey RefreshToken => new (RefreshTokenKey);
}