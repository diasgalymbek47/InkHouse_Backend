namespace InkHouse.Models.Dto;

public sealed record UserDto
{
    public string Login { get; set; }
    public string Password { get; set; }
}