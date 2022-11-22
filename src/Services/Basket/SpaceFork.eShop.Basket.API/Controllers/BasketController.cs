using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.Entity;

namespace SpaceFork.eShop.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            this._basketService = basketService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> UpdateUserBasket(ShoppingCart shoppingCart)
        {
            var result = await _basketService.UpdateUserBasket(shoppingCart);
            return Ok(result);
        }

        [HttpGet]
        [Route("{username}")]
        public async Task<ActionResult<ShoppingCart>> GetUserBasket(string username)
        {
            var result = await _basketService.GetUserBasket(username);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUserResult (string username)
        {
            await _basketService.DeleteUserBasket(username);
            return Ok(true);
        }

    }
}
