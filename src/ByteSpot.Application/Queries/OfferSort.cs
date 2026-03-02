using System.Text.Json.Serialization;

namespace ByteSpot.Application.Queries;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OfferSort
{
    Latest,
    HighestSalary,
    LowestSalary
}