using Basket.API.Data;

namespace Basket.API.Basket.AddBasket;

public record AddBasketCommand(ShoppingCart Cart) : ICommand<bool>;

public class AddBasketHandler(IBasketRepository basketRepository) : ICommandHandler<AddBasketCommand, bool>
{
    public async Task<bool> Handle(AddBasketCommand request, CancellationToken cancellationToken)
    {
        var result = await basketRepository.CreateAsync(request.Cart);
        return result;
    }
}