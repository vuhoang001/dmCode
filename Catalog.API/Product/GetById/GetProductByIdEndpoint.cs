namespace Catalog.API.Product.GetById;

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id:guid}",
            async (Guid id, ISender sender) =>

            {
                var request = new GetProductByIdCommand(id);
                var result  = await sender.Send(request);

                return result;
            });
    }
}