namespace ByteSpot.Modules.Users.Application.Auth;

public interface IPasswordManager
{
    string Secure(string password);
    bool Validate(string password, string securedPassword);
}