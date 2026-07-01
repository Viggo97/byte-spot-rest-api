using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidFirstNameException(string firstName, int minLength, int maxLength) 
    : ByteSpotException($"First name: {firstName} contains {firstName.Length} characters, but should be between {minLength} and {maxLength}."){
    public string FirstName { get; } = firstName;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}