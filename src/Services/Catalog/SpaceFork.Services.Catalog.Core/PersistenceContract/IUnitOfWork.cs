using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Catalog.Core.PersistenceContract
{
    public interface IUnitOfWork
    {
        ICatalogRepository catalogRepository { get; }
    }
}
