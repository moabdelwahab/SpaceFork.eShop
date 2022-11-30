using Microsoft.EntityFrameworkCore;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;

namespace SpaceFork.eShop.Ordering.Persistence.Repositories
{
    public class OrderRepository : AsyncRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrdersByUserName(string username)
        {
            throw new NotImplementedException();
        }
    }
}
