using InkHouse.Models;

namespace InkHouse.Interfaces;

public interface IPictureService
{
    Task<IEnumerable<Picture>> GetAllAsync();
}