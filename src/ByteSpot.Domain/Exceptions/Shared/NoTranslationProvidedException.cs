namespace ByteSpot.Domain.Exceptions.Shared;

public sealed class NoTranslationProvidedException() : CustomException("No translation provided for specified languages.");