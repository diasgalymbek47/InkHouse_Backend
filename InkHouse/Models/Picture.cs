namespace InkHouse.Models;

public sealed record Picture
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Params { get; set; }
    public decimal Price { get; set; }
    public string Country { get; set; }
    public string UrlImage { get; set; }
};