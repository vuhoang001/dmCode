using Basket.API.Exception;

namespace Basket.API.Data;

public class BasketRepository : IBasketRepository
{
    private readonly IDocumentSession _session;

    public BasketRepository(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default)
    {
        var basket = await _session.LoadAsync<ShoppingCart>(username, cancellationToken);
        return basket is null ? throw new ApiNotFoundException() : basket;
    }

    public async Task<bool> CreateAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        _session.Store(cart);
        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(string username, CancellationToken cancellationToken = default)
    {
        var result = await GetBasketAsync(username, cancellationToken);
        _session.Delete(result);

        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }
}