using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class InvalidRefreshTokenException() : ByteSpotException("Invalid refresh token.")
{ }