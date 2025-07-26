namespace Catalog.API.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageLink { get; set; }
    public List<string> Categories { get; set; } = [];
    public decimal Price { get; set; }
}