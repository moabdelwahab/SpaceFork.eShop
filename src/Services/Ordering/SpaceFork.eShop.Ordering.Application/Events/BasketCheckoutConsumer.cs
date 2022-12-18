using AutoMapper;
using MassTransit;
using MediatR;
using SpaceFork.eShop.EventBus.Messages.Events;
using SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;

namespace SpaceFork.eShop.Ordering.Application.Events
{
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BasketCheckoutConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            try
            {
                var mappedRequest = _mapper.Map<CheckOutOrderRequest>(context.Message);

                var query = new CheckoutOrderCommand(mappedRequest);

                var result = await _mediator.Send(query);
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }
    }
}
