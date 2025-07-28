using BuildingBlocks;
using Catalog.API.Exceptions;

namespace Catalog.API.Product.GetById;

public record GetProductByIdCommand(
    Guid Id) : IQuery<Models.Product>;

public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdCommand, Models.Product>
{
    public async Task<Models.Product> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await session.Query<Models.Product>().FirstOrDefaultAsync(p => p.Id == request.Id);
        if (product is null) throw new ApiNotFoundException();

        return product;
    }
}