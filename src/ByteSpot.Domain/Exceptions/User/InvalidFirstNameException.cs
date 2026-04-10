namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidFirstNameException(string firstName, int minLength, int maxLength) 
    : CustomException($"First name: {firstName} contains {firstName.Length} characters, but should be between {minLength} and {maxLength}."){
    public string FirstName { get; } = firstName;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}