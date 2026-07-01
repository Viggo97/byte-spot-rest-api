using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public class UserNotFoundException() : ByteSpotException("User was not found.");