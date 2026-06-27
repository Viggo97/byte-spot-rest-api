namespace ByteSpot.Shared.Abstractions.Auth;

public sealed record AccessTokenClaims(
    string Sub,
    string UniqueName,
    string Email,
    string Role
);