using MediatR;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<bool>
    {
        public UpdateOrderCommand(UpdateOrderRequest updateOrderRequest)
        {
            UpdateOrderRequest = updateOrderRequest ?? throw new ArgumentNullException(nameof(updateOrderRequest));
        }

        public UpdateOrderRequest UpdateOrderRequest { get; set; } = new UpdateOrderRequest();
    }
}
