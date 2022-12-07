using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using SpaceFork.eShop.Ordering.Application.Exceptions;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, bool>
    {

        private readonly ILogger<UpdateOrderCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UpdateOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = await _unitOfWork.OrderRepository.GetByIdAsync(request.UpdateOrderRequest.Id);

            if (orderToUpdate == null)
            {
                _logger.LogError($"Order with Id {request.UpdateOrderRequest.Id} is not found");

                throw new NotFoundException(nameof(Order), request.UpdateOrderRequest.Id);
            }

            _mapper.Map(request, orderToUpdate, typeof(UpdateOrderCommand), typeof(Order));

            await _unitOfWork.OrderRepository.UpdateAsync(orderToUpdate);

            return true;
        }

    }
}
