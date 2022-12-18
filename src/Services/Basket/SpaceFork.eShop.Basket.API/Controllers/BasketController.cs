using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Basket.Core.ApplicationContract;
using SpaceFork.eShop.Basket.Core.Entity;
using SpaceFork.eShop.Basket.Core.EventModels;
using SpaceFork.eShop.Basket.Core.InfrastructureContract;

namespace SpaceFork.eShop.Basket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IDiscountGrpcService _discountGrpcService;

        public BasketController(IBasketService basketService, IDiscountGrpcService discountGrpcService)
        {
            this._basketService = basketService;
            _discountGrpcService = discountGrpcService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> UpdateUserBasket(ShoppingCart shoppingCart)
        {
            //Checking For Discounsts
            await _discountGrpcService.UpdateCartWithDiscount(shoppingCart);

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
        public async Task<ActionResult<bool>> DeleteUserResult(string username)
        {
            await _basketService.DeleteUserBasket(username);
            return Ok(true);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            await _basketService.Checkout(basketCheckout);
            return Ok();

        }
    }
}
