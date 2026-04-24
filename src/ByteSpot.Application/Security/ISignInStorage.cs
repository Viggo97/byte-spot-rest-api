using ByteSpot.Application.Dto;

namespace ByteSpot.Application.Security;

public interface ISignInStorage
{
    void Set(UserDto userDto);
    UserDto Get();
}