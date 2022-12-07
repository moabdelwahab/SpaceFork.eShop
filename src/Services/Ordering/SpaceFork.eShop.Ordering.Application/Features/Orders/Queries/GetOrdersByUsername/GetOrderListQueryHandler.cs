using AutoMapper;
using MediatR;
using SpaceFork.eShop.Ordering.Core.Contracts.Persistence;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.ViewModels;

namespace SpaceFork.eShop.Ordering.Application.Features.Orders.Queries
{
    public class GetOrderListQueryHandler : IRequestHandler<GetOrdersListQuery, List<Order>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(IUnitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(IMapper));
        }

        public async Task<List<Order>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.OrderRepository.GetOrdersByUserName(request.UserName);
            if (result != null && result.Count() > 0)
            {
                return _mapper.Map<List<Order>>(result);
            }
            else
                return new List<Order>();

        }
    }
}
