using BuildingBlocks;
using Catalog.API.Exceptions;

namespace Catalog.API.Product.Delete;

public record DeleteProductCommand(Guid Id) : ICommand<Unit>;

public class DeleteProductHandler(IDocumentSession session) : IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await session.Query<Models.Product>().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (result is null) throw new ApiNotFoundException();

        session.Delete(result);
        await session.SaveChangesAsync();
        return Unit.Value;
    }
}