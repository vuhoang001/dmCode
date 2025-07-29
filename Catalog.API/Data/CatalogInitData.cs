using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();
        if (await session.Query<Models.Product>().AnyAsync())
            return;

        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Models.Product> GetPreconfiguredProducts() => new List<Models.Product>()
    {
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "iPhone X",
            Description = "This phone is the company's biggest change in years.",
            ImageLink   = "product1.png",
            Categories  = new List<string> { "Smart Phone" },
            Price       = 950.00M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Samsung Galaxy S21",
            Description = "Flagship smartphone with stunning design and performance.",
            ImageLink   = "product2.png",
            Categories  = new List<string> { "Smart Phone" },
            Price       = 899.99M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "MacBook Pro 14\"",
            Description = "Apple M1 Pro chip delivers exceptional performance for pros.",
            ImageLink   = "product3.png",
            Categories  = new List<string> { "Laptop" },
            Price       = 1999.00M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Dell XPS 13",
            Description = "Ultra-thin laptop with InfinityEdge display.",
            ImageLink   = "product4.png",
            Categories  = new List<string> { "Laptop" },
            Price       = 1299.00M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Sony WH-1000XM5",
            Description = "Industry-leading noise canceling wireless headphones.",
            ImageLink   = "product5.png",
            Categories  = new List<string> { "Headphones" },
            Price       = 349.99M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Apple Watch Series 8",
            Description = "Advanced health sensors and new safety features.",
            ImageLink   = "product6.png",
            Categories  = new List<string> { "Smart Watch" },
            Price       = 399.00M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "iPad Pro 12.9",
            Description = "Powered by M2 chip, ultimate iPad experience.",
            ImageLink   = "product7.png",
            Categories  = new List<string> { "Tablet" },
            Price       = 1099.00M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "GoPro HERO11",
            Description = "Action camera with 5.3K video and waterproof design.",
            ImageLink   = "product8.png",
            Categories  = new List<string> { "Camera" },
            Price       = 499.99M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Logitech MX Master 3",
            Description = "Advanced ergonomic mouse with ultra-fast scrolling.",
            ImageLink   = "product9.png",
            Categories  = new List<string> { "Accessories" },
            Price       = 99.99M
        },
        new Models.Product
        {
            Id          = Guid.NewGuid(),
            Name        = "Kindle Paperwhite",
            Description = "Waterproof e-reader with adjustable warm light.",
            ImageLink   = "product10.png",
            Categories  = new List<string> { "E-Reader" },
            Price       = 139.99M
        }
    };
}