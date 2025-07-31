using Basket.API.Data;

namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string Username) : ICommand<bool>;

public class DeleteBasketHandler(IBasketRepository basketRepository) : IRequestHandler<DeleteBasketCommand, bool>
{
    public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
    {
        var result = await basketRepository.DeleteAsync(request.Username);
        return result;
    }
}