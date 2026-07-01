using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class RefreshTokenNotFoundException() : ByteSpotException("Refresh token was not found.");