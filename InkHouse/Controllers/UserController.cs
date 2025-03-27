using InkHouse.Interfaces;
using InkHouse.Models;
using InkHouse.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace InkHouse.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class UserController(IUserService service) : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<ActionResult<User>> RegistrationAsync(UserDto userDto)
    {
        return Ok(await service.RegistrationAsync(userDto));
    }

    [HttpPost]
    [Route("auth")]
    public async Task<IActionResult> AuthorizationAsync(UserDto userDto)
    {
        await service.AuthorizationAsync(userDto);
        return Ok(new { message = "Успешная авторизация!" });
    }
}