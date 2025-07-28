using Catalog.API.Product.Create;

namespace Catalog.API.Product.Update;

public record UpdateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    string? ImageLink,
    List<string> Categories);

public class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{id}", async (Guid id, UpdateProductRequest update, ISender sender) =>
        {
            var command = update.Adapt<UpdateProductByIdCommand>()with { Id = id };
            var result  = await sender.Send(command);
            return result;
        });
    }
}