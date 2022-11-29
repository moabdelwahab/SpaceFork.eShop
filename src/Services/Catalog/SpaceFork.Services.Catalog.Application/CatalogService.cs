using AutoMapper;
using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Catalog.Core;
using SpaceFork.eShop.Catalog.Core.Dto;
using SpaceFork.eShop.Catalog.Core.Entity;
using SpaceFork.eShop.Catalog.Core.PersistenceContract;
using SpaceFork.eShop.Catalog.Core.ServicesContract;

namespace SpaceFork.eShop.Catalog.Application
{
    public class CatalogService : ICatalogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CatalogService> _logger;

        public CatalogService(IUnitOfWork unitOfWork,IMapper mapper,ILogger<CatalogService> logger )
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Create(CreateProductDto product)
        {
            var mapperProduct = _mapper.Map<Product>(product);
            await _unitOfWork.catalogRepository.CreateProduct(mapperProduct);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _unitOfWork.catalogRepository.DeleteProduct(id);
            return true;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            var products = await _unitOfWork.catalogRepository.GetProductByCategory(category);
            return products;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _unitOfWork.catalogRepository.GetProduct(id);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            return await _unitOfWork.catalogRepository.GetProductByName(name);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _unitOfWork.catalogRepository.GetProducts();
            _logger.LogInformation("This is success messaga from Catalog Service after calling Repository and get All Products then it will back to Controller ");
            return products;
        }

        public async Task<bool> Update(UpdateProductDto updateproductDto)
        {
            var mapperProduct = _mapper.Map<Product>(updateproductDto);
            await _unitOfWork.catalogRepository.UpdateProduct(mapperProduct);
            return true;
        }
    }
}
