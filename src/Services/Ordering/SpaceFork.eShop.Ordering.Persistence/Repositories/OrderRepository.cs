using Microsoft.EntityFrameworkCore;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;
using SpaceFork.eShop.Ordering.Persistence.DatabaseContext;

namespace SpaceFork.eShop.Ordering.Persistence.Repositories
{
    public class OrderRepository : AsyncRepository<Order>, IOrderRepository
    {
        private readonly OrderDbContext _dbContext;

        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string username)
        {
            if (!string.IsNullOrEmpty(username))
                return await _dbContext.Orders.Where(order => order.UserName.ToLower() == username.ToLower()).ToListAsync();
            return new List<Order>();
        }
    }
}
