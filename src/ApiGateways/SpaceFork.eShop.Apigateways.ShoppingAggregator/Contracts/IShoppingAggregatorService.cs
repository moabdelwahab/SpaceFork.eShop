using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts
{
    public interface IShoppingAggregatorService
    {
        Task<ShoppingModel> GetUserShoppingDetails(string username);
    }
}
