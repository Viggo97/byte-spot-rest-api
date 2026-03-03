using System.Text.Json.Serialization;

namespace ByteSpot.Application.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OfferSuggestionCategory
{
    Location,
    Technology,
    Company,
    Title,
}