using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceFork.eShop.Ordering.Core.Contracts.Application;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.ViewModels;

namespace SpaceFork.eShop.Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderingService _orderingService;

        public OrderController(IOrderingService orderingService)
        {
            _orderingService = orderingService;
        }

        [HttpGet("{username}", Name = "GetOrders")]
        public async Task<ActionResult<List<Order>>> GetOrderByUsername(string username)
        {
            var result = await _orderingService.GetOrdersOfUser(username);
            if (result.Count > 0)
                return Ok(result);
            else
                return NotFound(result);
        }

        [HttpPost(Name = "CheckoutOrder")]
        public async Task<ActionResult<int>> CheckoutOrder([FromBody] CheckOutOrderRequest checkOutOrderRequest)
        {
            var result = await _orderingService.CreateOrder(checkOutOrderRequest);
            if (result > 0)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpPut(Name = "UpdateOrder")]
        public async Task<ActionResult<bool>> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var result = await _orderingService.UpdateOrder(updateOrderRequest);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete(Name = "DeleteOrder")]
        public async Task<ActionResult<bool>> DeleteOrder(int orderId)
        {
            var result = await _orderingService.DeleteOrder(orderId);
            if (result)
                return Ok(result);
            else
                return BadRequest(result);
        }

    }
}
