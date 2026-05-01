using ByteSpot.Application.Abstractions;
using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Queries.WorkMode;

public sealed record GetWorkModeQuery(int Id) : IQuery<WorkModeWithTranslationsDto>;