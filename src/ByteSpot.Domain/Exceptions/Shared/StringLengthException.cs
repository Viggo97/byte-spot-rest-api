namespace ByteSpot.Domain.Exceptions.Shared;

public class StringLengthException(string phrase, int length) 
    : CustomException($"String length must be of length {length}.")
{
    public string Phrase { get; } = phrase;
    public int Length { get; } = length;
}
