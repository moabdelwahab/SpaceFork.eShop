using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFork.eShop.Catalog.Core.Dto;
using SpaceFork.eShop.Catalog.Core.Entity;

namespace SpaceFork.eShop.Catalog.Core.ServicesContract
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByCategory(string category);

        Task<bool> Create(CreateProductDto product);
        Task<bool> Update(UpdateProductDto product);
        Task<bool> Delete(string id);

    }
}
