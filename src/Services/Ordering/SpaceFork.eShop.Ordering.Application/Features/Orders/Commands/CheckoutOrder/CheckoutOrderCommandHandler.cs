using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Ordering.Core.Contracts.Infrastructure;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;
using SpaceFork.eShop.Ordering.Core.Models;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder
{
    public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CheckoutOrderCommand> _logger;
        private readonly IEmailService _emailService;

        public CheckoutOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<CheckoutOrderCommand> logger, IEmailService emailService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var orderRequest = _mapper.Map<Order>(request.CheckOutOrderRequest);
                var result = await _unitOfWork.OrderRepository.AddAsync(orderRequest);
                await _emailService.SendEmail(OrderSentEmail(orderRequest));
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Email OrderSentEmail(Order order)
        {
            return new Email()
            {
                Body = $"Dear {order.FirstName} {order.LastName}, Kindly infromed that your Order with total Price : {order.TotalPrice} is Submitted",
                From = $"mhmad.abdelwahab@outlook.com",
                Subject = $"eShop Order has been submitted",
                To = "mhmad.abdelwahab@outlook.com"
            };
        }

    }
}
