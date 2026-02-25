namespace ByteSpot.Domain.Exceptions.Shared;

public class StringLengthOutOfRangeException(string phrase, int minLength, int maxLength) 
    : CustomException($"String length should be between {minLength} and {maxLength}.")
{
    public string Phrase { get; } = phrase;
    public int MinLength { get; } = minLength;
    public int MaxLength { get; } = maxLength;
}
