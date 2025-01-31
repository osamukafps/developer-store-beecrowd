namespace DeveloperStore.Api.Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public string Category { get; private set; }
    public string Image { get; private set; }
    public Rating Rating { get; private set; }
    
    private Product() { }

    public Product(int id, string title, string description, double price, string category, string image, Rating rating)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Category = category;
        Image = image;
        Rating = rating;
    }
}

public class Rating
{
    public int Count { get; set; }
    public double Rate { get; set; }
}