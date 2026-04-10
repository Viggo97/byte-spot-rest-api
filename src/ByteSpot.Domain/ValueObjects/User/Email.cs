using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using ByteSpot.Domain.Exceptions.Shared;
using ByteSpot.Domain.Exceptions.User;

namespace ByteSpot.Domain.ValueObjects.User;

public sealed record Email
{
    private static readonly Regex Regex = new(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled);
        
    public string Value { get; }

    public Email(string value, [CallerArgumentExpression(nameof(value))] string? prop = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidStringContentException(prop);
        }
        
        value = value.Trim();

        const int minLength = 2;
        const int maxLength = 64;
        if (value.Length is > maxLength or < minLength)
        {
            throw new InvalidEmailException(value, minLength, maxLength);
        }

        value = value.ToLowerInvariant();
        if (!Regex.IsMatch(value))
        {
            throw new InvalidEmailPatternException(value);
        }

        Value = value;
    }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);
        
    public override string ToString() => Value;
}