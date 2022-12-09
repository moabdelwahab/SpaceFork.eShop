using MediatR;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<int>
    {
        public CheckoutOrderCommand(CheckOutOrderRequest checkOutOrderRequest)
        {
            CheckOutOrderRequest = checkOutOrderRequest ?? throw new ArgumentNullException(nameof(CheckoutOrderCommand));
        }

        public CheckOutOrderRequest CheckOutOrderRequest { get; set; } = new CheckOutOrderRequest();
    }
}
