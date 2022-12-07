using MediatR;
using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder;
using SpaceFork.eShop.Ordering.Application.Features.Orders.DeleteOrder;
using SpaceFork.eShop.Ordering.Application.Features.Orders.Queries;
using SpaceFork.eShop.Ordering.Application.Features.Orders.UpdateOrder;
using SpaceFork.eShop.Ordering.Core.Contracts.Application;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.ViewModels;

namespace SpaceFork.eShop.Ordering.Application.Services
{
    public class OrderingService : IOrderingService
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderingService> _logger;

        public OrderingService(IMediator mediator, ILogger<OrderingService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<int> CreateOrder(CheckOutOrderRequest checkOutOrderRequest)
        {
            var query = new CheckoutOrderCommand(checkOutOrderRequest);
            var result = await _mediator.Send(query);
            return result;

        }

        public async Task<bool> DeleteOrder(int orderId)
        {
            var query = new DeleteOrderCommand(orderId);
            var result = await _mediator.Send(query);
            return result;
        }

        public async Task<List<Order>> GetOrdersOfUser(string username)
        {
            var query = new GetOrdersListQuery(username);
            var orders = await _mediator.Send(query);

            if (orders?.Count > 0)
            {
                return orders.ToList();
            }

            return new List<Order>();
        }

        public async Task<bool> UpdateOrder(UpdateOrderRequest updateOrderRequest )
        {
            var query = new UpdateOrderCommand(updateOrderRequest);
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
