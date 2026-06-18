namespace ByteSpot.Domain.Exceptions.ExperienceLevel;

public class InvalidNumberOfExperienceLevelsException() 
    : CustomException("The number of provided experience levels is too small. You have to add at least one.");

