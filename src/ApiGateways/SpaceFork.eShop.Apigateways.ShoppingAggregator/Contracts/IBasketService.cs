using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts
{
    public interface IBasketService
    {
        Task<Basket> GetUserBasket(string username);
    }
}
