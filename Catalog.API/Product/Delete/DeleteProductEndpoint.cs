namespace Catalog.API.Product.Delete;

public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id:guid}", async (Guid id, ISender sender) =>
        {
            var result  = new DeleteProductCommand(id);
            var command = await sender.Send(result);
            return command;
        });
    }
}