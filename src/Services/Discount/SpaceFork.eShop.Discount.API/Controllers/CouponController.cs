using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Discount.Core.ApplicationContract;
using SpaceFork.eShop.Discount.Core.Entity;

namespace SpaceFork.eShop.Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public CouponController(IDiscountService discountService)
        {
            this._discountService = discountService;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<ActionResult<Coupon>> GetProductCoupon(string productId)
        {
            var coupon = await _discountService.GetProductCoupon(productId);
            return Ok(coupon);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<ActionResult<bool>> DeleteCoupon(string productId)
        {
            var result = await _discountService.DeleteCoupon(productId);
            return Ok(result);
        }
   
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCoupon(Coupon coupon)
        {
            var result = await _discountService.UpdateProductCoupon(coupon);
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<bool>> CreateCoupon(Coupon coupon)
        {
            var result = await _discountService.AddProductCoupon(coupon);
            return Ok(result);
        }

    }
}
