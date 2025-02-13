namespace DeveloperStore.Api.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public double AverageRating { get; set; }
    public int RatingCount { get; set; }
}