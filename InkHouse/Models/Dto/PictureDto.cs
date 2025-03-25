namespace InkHouse.Models.Dto;

public sealed record PictureDto
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Params { get; set; }
    public decimal Price { get; set; }
    public string Country { get; set; }
    public IFormFile Image { get; set; }
}