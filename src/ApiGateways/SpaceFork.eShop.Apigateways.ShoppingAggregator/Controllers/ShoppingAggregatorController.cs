using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Contracts;
using SpaceFork.eShop.Apigateways.ShoppingAggregator.Models;

namespace SpaceFork.eShop.Apigateways.ShoppingAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingAggregatorController : ControllerBase
    {
        private readonly IShoppingAggregatorService _shoppingAggregatorService;

        public ShoppingAggregatorController(IShoppingAggregatorService shoppingAggregatorService)
        {
            _shoppingAggregatorService = shoppingAggregatorService;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<ShoppingModel>> GetUserShoppingDetails(string username)
        {
            var shoppingDetails = await _shoppingAggregatorService.GetUserShoppingDetails(username);

            return Ok(shoppingDetails);

        }
    }
}
