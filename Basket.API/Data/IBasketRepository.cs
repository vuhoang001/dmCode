namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default);
    Task<bool> CreateAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
    Task<bool>         DeleteAsync(string username, CancellationToken cancellationToken = default);
}