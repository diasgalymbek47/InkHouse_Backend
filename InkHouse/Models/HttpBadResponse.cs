namespace InkHouse.Models;

public record HttpBadResponse
{
    public string Message { get; set; }
    public string Details { get; set; }
};