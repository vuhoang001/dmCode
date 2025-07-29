namespace Catalog.API.Product.List;

public record GetListRequest(int? PageNumber = 1, int? PageSize = 20);

public class ListProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetListRequest request, ISender sender) =>
        {
            var query  = request.Adapt<ListProductsQuery>();
            var result = await sender.Send(query);
            return Results.Ok(result);
        });
    }
}