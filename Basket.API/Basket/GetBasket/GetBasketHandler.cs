using Basket.API.Data;

namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string Username) : IQuery<ShoppingCart>;

public class GetBasketHandler(IBasketRepository basketRepository) : IQueryHandler<GetBasketQuery, ShoppingCart>
{
    public async Task<ShoppingCart> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var result = await basketRepository.GetBasketAsync(query.Username);
        return result;
    }
}