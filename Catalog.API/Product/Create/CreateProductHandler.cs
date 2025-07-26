using System.Windows.Input;
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

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Models.Product
        {
            Name = command.Name,
            Description = command.Description,
            ImageLink = command.ImageLink,
            Categories = command.Categories,
            Price = command.Price,
        };

        return Task.FromResult(product.Adapt<CreateProductResult>());
    }
}