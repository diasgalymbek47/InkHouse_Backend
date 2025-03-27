using InkHouse.Models;
using InkHouse.Models.Dto;

namespace InkHouse.Interfaces;

public interface IUserRepository
{
    Task<User> AddUserAsync(UserDto userDto);
    Task<User> GetUserByLoginAsync(string login);
    Task<bool> CheckUserAsync(string login);
}