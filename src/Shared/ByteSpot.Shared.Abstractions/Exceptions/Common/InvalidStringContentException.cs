namespace ByteSpot.Shared.Abstractions.Exceptions.Common;

public class InvalidStringContentException(string? objName = null) 
    : ByteSpotException($"String cannot contain whitespaces or be null{(objName is not null ? $" for: {objName}." : ".")}");
