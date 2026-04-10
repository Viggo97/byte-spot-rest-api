namespace ByteSpot.Domain.Exceptions.Shared;

public class InvalidStringContentException(string? objName = null) 
    : CustomException($"String cannot contain whitespaces or be null{(objName is not null ? $" for: {objName}." : ".")}");
