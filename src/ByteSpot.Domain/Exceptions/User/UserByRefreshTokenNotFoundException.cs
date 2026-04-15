namespace ByteSpot.Domain.Exceptions.User;

public class UserByRefreshTokenNotFoundException(string refreshToken) : CustomException("User with such refresh token was not found.")
{
    public string RefreshToken { get; } = refreshToken;
}