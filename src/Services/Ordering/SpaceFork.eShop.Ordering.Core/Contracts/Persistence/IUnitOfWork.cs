using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Core.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public IOrderRepository OrderRepository { get; }
    }
}
