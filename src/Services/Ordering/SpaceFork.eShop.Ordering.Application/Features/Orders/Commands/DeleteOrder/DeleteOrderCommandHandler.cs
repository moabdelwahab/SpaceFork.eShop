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

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ILogger<DeleteOrderCommandHandler> logger)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToDelete = await _unitOfWork.OrderRepository.GetByIdAsync(request.Id);

            if (orderToDelete == null)
            {
                _logger.LogError($"Order with Id : {request.Id} is not exist in the Database ");
                throw new NotFoundException(nameof(Order), request.Id);
            }

             await _unitOfWork.OrderRepository.DeleteAsync(orderToDelete);

            return true;
        }
    }
}
