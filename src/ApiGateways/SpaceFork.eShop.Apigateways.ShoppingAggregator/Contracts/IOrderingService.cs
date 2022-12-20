using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts
{
    public interface IOrderingService
    {
        Task<IEnumerable<OrderResponseModel>> GetUserOrders(string userName);
    }
}
