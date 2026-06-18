namespace ByteSpot.Domain.Exceptions.Technology;

public class InvalidNumberOfTechnologiesException() 
    : CustomException("The number of provided technologies is too small. You have to add at least one.");

