using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class PasswordDoesNotMatchException() : ByteSpotException("Password does not match.");