using ByteSpot.Shared.Abstractions.Exceptions;

namespace ByteSpot.Modules.Users.Domain.Exceptions;

public sealed class InvalidRoleException(string role, IEnumerable<string> validRoles) 
    : ByteSpotException($"Role {role} is invalid. Supported roles: {validRoles}.")
{
    public string Role { get; } = role;
}