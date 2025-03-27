namespace InkHouse.Models;

public sealed record User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
};