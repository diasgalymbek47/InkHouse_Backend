using System.Net;
using InkHouse.Exceptions;
using InkHouse.Interfaces;
using InkHouse.Models;
using InkHouse.Models.Dto;

namespace InkHouse.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<User> RegistrationAsync(UserDto userDto) => await repository.AddUserAsync(userDto);

    public async Task AuthorizationAsync(UserDto userDto)
    {
        var user = await repository.GetUserByLoginAsync(userDto.Login);
        if (userDto.Password != user.Password) throw new HttpException("Пароль не верный!", HttpStatusCode.BadRequest);
    }
}