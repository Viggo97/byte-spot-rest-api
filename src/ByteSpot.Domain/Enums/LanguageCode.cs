using System.Text.Json.Serialization;

namespace ByteSpot.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LanguageCode
{
    En,
    Pl,
}