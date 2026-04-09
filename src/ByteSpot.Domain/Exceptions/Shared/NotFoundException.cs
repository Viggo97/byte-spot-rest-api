namespace ByteSpot.Domain.Exceptions.Shared;

public class NotFoundException(string message) : CustomException(message);