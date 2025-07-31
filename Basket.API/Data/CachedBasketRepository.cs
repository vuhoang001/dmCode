using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Data;

public class CachedBasketRepository(IBasketRepository basketRepository, IDistributedCache cache) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketAsync(string username, CancellationToken cancellationToken = default)
    {
        var cached = await cache.GetStringAsync(username, cancellationToken);
        if (!string.IsNullOrEmpty(cached))
            return JsonSerializer.Deserialize<ShoppingCart>(cached)!;


        var basket = await basketRepository.GetBasketAsync(username, cancellationToken);
        await cache.SetStringAsync(username, JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<bool> CreateAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        await basketRepository.CreateAsync(cart, cancellationToken);
        await cache.SetStringAsync(cart.UserName, JsonSerializer.Serialize(cart), cancellationToken);

        return true;
    }

    public async Task<bool> DeleteAsync(string username, CancellationToken cancellationToken = default)
    {
        await basketRepository.DeleteAsync(username, cancellationToken);
        await cache.RemoveAsync(username, cancellationToken);
        return true;
    }
}