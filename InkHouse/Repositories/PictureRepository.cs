using System.Data;
using Dapper;
using InkHouse.Interfaces;
using InkHouse.Models;

namespace InkHouse.Repositories;

public class PictureRepository(IDbConnection connection) : IPictureRepository
{
    public async Task<IEnumerable<Picture>> GetAllAsync()
    {
        const string sql = $"""
                           select
                           id as {nameof(Picture.Id)},
                           name as {nameof(Picture.Name)},
                           author as {nameof(Picture.Author)},
                           params as {nameof(Picture.Params)},
                           price as {nameof(Picture.Price)},
                           country as {nameof(Picture.Country)},
                           image as {nameof(Picture.UrlImage)}
                           from pictures
                           """;
        return await connection.QueryAsync<Picture>(sql);
    }
}