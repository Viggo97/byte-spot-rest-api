namespace ByteSpot.Domain.Exceptions.Offer;

public sealed class SalaryNotProvidedException() 
    : CustomException($"No salary was provided.");