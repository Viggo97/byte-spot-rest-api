namespace ByteSpot.Shared.Abstractions.Auth;

public interface IAuthenticator
{
    (string accessToken, DateTimeOffset expires) CreateAccessToken(AccessTokenClaims claims);
    public (string token, Guid tokenId, DateTimeOffset expires) CreateRefreshToken();
    public void AppendAuthTokenCookie(string cookieKey, string token, DateTimeOffset expiration);
    public void DeleteAuthTokenCookie(string cookieKey);
}