using InkHouse.Models;

namespace InkHouse.Interfaces;

public interface IPictureRepository
{
    Task<IEnumerable<Picture>> GetAllAsync();
}