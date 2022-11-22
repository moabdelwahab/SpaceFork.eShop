using Microsoft.Extensions.Caching.Distributed;
using SpaceFork.eShop.Basket.Core.Entity;
using SpaceFork.eShop.Basket.Core.PersistenceContract;
using System.Text.Json;

namespace SpaceFork.eShop.Basket.Persistence;
public class BasketRepository : IBasketRepository
{
    private readonly IDistributedCache _redisCache;
    public BasketRepository(IDistributedCache redisCache)
    {
        _redisCache = redisCache ?? throw new ArgumentNullException();
    }

    public async Task<ShoppingCart> GetUserBasket(string username)
    {
        var basket = await _redisCache.GetStringAsync(username);

        if (string.IsNullOrEmpty(basket)) return null;

        var deserializedBasket = JsonSerializer.Deserialize<ShoppingCart>(basket);

        if (deserializedBasket == null)
            return null;
        else return deserializedBasket;

    }

    public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
    {
        string serializedBasket = JsonSerializer.Serialize(shoppingCart);
        await _redisCache.SetStringAsync(shoppingCart.Username, serializedBasket);
        return shoppingCart;
    }
    public async Task DeleteUserBasket(string username)
    {
        await _redisCache.RemoveAsync(username);
    }

}
