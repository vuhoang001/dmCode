namespace Catalog.API.Product.List;

public class ListProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new ListProductsQuery());
            return Results.Ok(result);
        });
    }
}