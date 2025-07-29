using BuildingBlocks;
using Marten.Pagination;

namespace Catalog.API.Product.List;

public record ListProductsQuery(int PageNumber = 1, int PageSize = 20) : IQuery<ListProductsResult>
{
}

public record ListProductsResult(IEnumerable<Models.Product> Products);

public class ListProductsHandler(IDocumentSession session, ILogger<ListProductsHandler> logger)
    : IQueryHandler<ListProductsQuery, ListProductsResult>
{
    public async Task<ListProductsResult> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Models.Product>()
            .ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
        return new ListProductsResult(products);
    }
}