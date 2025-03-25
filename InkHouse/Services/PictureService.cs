using InkHouse.Interfaces;
using InkHouse.Models;

namespace InkHouse.Services;

public class PictureService(IPictureRepository repository) : IPictureService
{
    public async Task<IEnumerable<Picture>> GetAllAsync() => await repository.GetAllAsync();
}