using System.Data;
using System.Net;
using Dapper;
using InkHouse.Exceptions;
using InkHouse.Interfaces;
using InkHouse.Models;
using InkHouse.Models.Dto;

namespace InkHouse.Repositories;

public class UserRepository(IDbConnection connection) : IUserRepository
{
    public async Task<User> AddUserAsync(UserDto userDto)
    {
        var hasUser = await CheckUserAsync(userDto.Login);
        if (hasUser) throw new HttpException("Такой логин уже существует", HttpStatusCode.BadRequest);
        
        const string sql =
            $"insert into users(login, password) values (@{nameof(UserDto.Login)}, @{nameof(UserDto.Password)})" +
            "returning id, login, password";

        return await connection.QuerySingleAsync<User>(sql, userDto);
    }

    public async Task<User> GetUserByLoginAsync(string login)
    {
        const string sql = "select * from users where login = @login";
        var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { login });

        return user ?? throw new HttpException("Такой логин не существует", HttpStatusCode.NotFound);
    }

    public async Task<bool> CheckUserAsync(string login)
    {
        const string sql = "select * from users where login = @login";
        var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { login });
        return user is not null;
    }
}