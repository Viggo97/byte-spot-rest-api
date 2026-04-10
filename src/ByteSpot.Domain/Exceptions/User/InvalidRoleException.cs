namespace ByteSpot.Domain.Exceptions.User;

public sealed class InvalidRoleException(string role, IEnumerable<string> validRoles) 
    : CustomException($"Role {role} is invalid. Supported roles: {validRoles}.")
{
    public string Role { get; } = role;
}