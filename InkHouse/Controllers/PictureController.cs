using InkHouse.Interfaces;
using InkHouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace InkHouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController(IPictureService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Picture>>> GetAllAsync()
    {
        return Ok(await service.GetAllAsync());
    }
}