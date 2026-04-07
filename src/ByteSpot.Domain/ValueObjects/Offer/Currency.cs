using ByteSpot.Domain.Exceptions.Shared;

namespace ByteSpot.Domain.ValueObjects.Offer;

public sealed record Currency
{
    public string Code { get; }

    public Currency(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            throw new InvalidStringContentException();
        }

        const int codeLength = 3;
        if (code.Length != codeLength)
        {
            throw new StringLengthException(code, codeLength);
        }
        
        Code = code;
    }

    public static implicit operator string(Currency currency) => currency.Code;

    public static implicit operator Currency(string code) => new Currency(code);

    public override string ToString() => Code;
}