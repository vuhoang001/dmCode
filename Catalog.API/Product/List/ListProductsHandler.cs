using BuildingBlocks;

namespace Catalog.API.Product.List;

public record ListProductsQuery() : IQuery<ListProductsResult>
{
}

public record ListProductsResult(IEnumerable<Models.Product> Products);

public class ListProductsHandler(IDocumentSession session, ILogger<ListProductsHandler> logger)
    : IQueryHandler<ListProductsQuery, ListProductsResult>
{
    public async Task<ListProductsResult> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling ListProductsQuery");
        var products = await session.Query<Models.Product>().ToListAsync();
        return new ListProductsResult(products);
    }
}