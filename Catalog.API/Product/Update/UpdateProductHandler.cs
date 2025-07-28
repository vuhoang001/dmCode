using BuildingBlocks;
using Catalog.API.Exceptions;
using MediatR.Wrappers;

namespace Catalog.API.Product.Update;

public record UpdateProductByIdCommand(
    Guid Id,
    string Name,
    string? Description,
    string? ImageLink,
    List<string> Categories,
    decimal Price
) : ICommand<Models.Product>;

public class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductByIdCommand, Models.Product>
{
    public async Task<Models.Product> Handle(UpdateProductByIdCommand command, CancellationToken cancellationToken)
    {
        var product = await session.Query<Models.Product>().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (product is null) throw new ApiNotFoundException();

        command.Adapt(product);

        session.Update(product);
        await session.SaveChangesAsync();

        return product;
    }
}