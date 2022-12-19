using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Catalog.Core.Dto;
using SpaceFork.eShop.Catalog.Core.Entity;
using SpaceFork.eShop.Catalog.Core.ServicesContract;
using System.Net;

namespace SpaceFork.eShop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ICatalogService catalogService, ILogger<CatalogController> logger)
        {
            this._catalogService = catalogService;
            this._logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _catalogService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateProduct(CreateProductDto createProductDto)
        {
            var CreateResult = await _catalogService.Create(createProductDto);
            return Ok(CreateResult);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct(UpdateProductDto updateProdcutDto)
        {
            var CreateResult = await _catalogService.Update(updateProdcutDto);
            return Ok(CreateResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            var CreateResult = await _catalogService.Delete(id);
            return Ok(CreateResult);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProdcut(string id)
        {
            var product = await _catalogService.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with Id : {id}, not found");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("[action]/{Name}", Name = "GetProductByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Product>>> GetProdcutByName(string Name)
        {
            var product = await _catalogService.GetProductByName(Name);
            if (product == null)
            {
                _logger.LogWarning($"Product with Name : {Name}, not found");
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("[action]/{Category}", Name = "GetProductByCategory")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<Product>>> GetProdcutByCategory(string category)
        {
            var product = await _catalogService.GetProductByCategory(category);
            if (product == null)
            {
                _logger.LogWarning($"Product with Category : {category}, not found");
                return NotFound();
            }
            return Ok(product);
        }

    }
}
