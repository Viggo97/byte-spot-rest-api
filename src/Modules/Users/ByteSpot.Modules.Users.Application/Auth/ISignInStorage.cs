using ByteSpot.Modules.Users.Application.DTO;

namespace ByteSpot.Modules.Users.Application.Auth;

public interface ISignInStorage
{
    void Set(UserDto userDto);
    UserDto Get();
}