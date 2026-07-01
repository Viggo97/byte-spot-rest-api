using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class InvalidCredentialsException() : ByteSpotException("Invalid credentials.");