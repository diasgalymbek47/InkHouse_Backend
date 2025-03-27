using InkHouse.Models;
using InkHouse.Models.Dto;

namespace InkHouse.Interfaces;

public interface IUserService
{
    Task<User> RegistrationAsync(UserDto userDto);
    Task AuthorizationAsync(UserDto userDto);
}