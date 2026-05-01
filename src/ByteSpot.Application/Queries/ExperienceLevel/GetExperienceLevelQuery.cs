using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.ExperienceLevel;

public sealed record GetExperienceLevelQuery(int Id) : IQuery<ExperienceLevelWithTranslationsDto>;
