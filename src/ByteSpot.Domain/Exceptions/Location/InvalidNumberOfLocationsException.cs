namespace ByteSpot.Domain.Exceptions.Location;

public class InvalidNumberOfLocationsException() 
    : CustomException("The number of provided locations is too small. You have to add at least one.");

