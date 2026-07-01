using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class RefreshTokenExpiredException() : ByteSpotException("Refresh token expired.");