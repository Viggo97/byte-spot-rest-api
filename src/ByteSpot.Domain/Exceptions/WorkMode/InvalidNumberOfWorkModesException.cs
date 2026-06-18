namespace ByteSpot.Domain.Exceptions.WorkMode;

public class InvalidNumberOfWorkModesException() 
    : CustomException("The number of provided work modes is too small. You have to add at least one.");