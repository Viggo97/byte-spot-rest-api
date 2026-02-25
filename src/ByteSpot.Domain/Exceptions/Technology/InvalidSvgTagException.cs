namespace ByteSpot.Domain.Exceptions.Technology;

public class InvalidSvgTagException() : CustomException("String should start with <svg> and end with </svg> tags.");