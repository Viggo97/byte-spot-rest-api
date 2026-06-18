namespace ByteSpot.Domain.Exceptions.EmploymentType;

public class InvalidNumberOfEmploymentTypesException() 
    : CustomException("The number of provided employment types is too small. You have to add at least one.");

