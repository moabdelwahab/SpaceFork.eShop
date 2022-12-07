using Microsoft.EntityFrameworkCore;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Persistence.DatabaseContext;

namespace SpaceFork.eShop.Ordering.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderDbContext _dbContext;

        private readonly IOrderRepository _orderRepository;
        public UnitOfWork(IOrderRepository orderRepository, OrderDbContext dbContext)
        {
            _orderRepository = orderRepository;
            _dbContext = dbContext;
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                if( _orderRepository == null )
                {
                    throw new InvalidOperationException();
                }
                return _orderRepository;
            }
        }
    }
}
