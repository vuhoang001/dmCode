using BuildingBlocks;

namespace Catalog.API.Product.Create;

public record CreateProductCommand(
    string Name,
    List<string> Categories,
    string? Description,
    decimal Price,
    string? ImageLink
) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id, string Name, string? Description, decimal Price, string? ImageLink);

public class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Models.Product
        {
            Name = command.Name,
            Description = command.Description,
            ImageLink = command.ImageLink,
            Categories = command.Categories,
            Price = command.Price,
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return product.Adapt<CreateProductResult>();
    }
}