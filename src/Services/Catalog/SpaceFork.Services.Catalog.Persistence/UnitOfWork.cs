using SpaceFork.eShop.Catalog.Core.PersistenceContract;
using SpaceFork.eShop.Catalog.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Catalog.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ICatalogContext _catalogContext;
        private ICatalogRepository _catalogRepository;

        public UnitOfWork(ICatalogContext catalogContext)
        {
            this._catalogContext = catalogContext;
        }

        public ICatalogRepository catalogRepository
        {
            get
            {
                if (_catalogRepository == null)
                {
                    _catalogRepository = new CatalogRepository(_catalogContext);
                    return _catalogRepository;
                }
                return _catalogRepository;

            }
        }
    }
}
