using SpaceFork.eShop.Ordering.Core.Domain.Entity;

namespace SpaceFork.eShop.Ordering.Core.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string username);
    }
}
