namespace Catalog.API.Product.Create;

public record CreateProductRequest(
    string Name,
    List<string> Categories,
    string? Description,
    decimal Price,
    string? ImageLink
);

public record CreateProductResponse(Guid Id, string Name, string? Description, decimal Price, string? ImageLink);

public class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();
            return response;
        });
    }
}