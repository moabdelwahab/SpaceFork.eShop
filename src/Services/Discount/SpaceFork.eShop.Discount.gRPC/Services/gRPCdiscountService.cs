using AutoMapper;
using Grpc.Core;
using SpaceFork.eShop.Discount.Core.ApplicationContract;
using SpaceFork.eShop.Discount.Core.Entity;
using SpaceFork.eShop.Discount.gRPC.Protos;

namespace SpaceFork.eShop.Discount.gRPC.Services
{
    public class gRPCdiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IDiscountService _discountService;
        private readonly ILogger<gRPCdiscountService> _logger;
        private readonly IMapper _mapper;

        public gRPCdiscountService(IDiscountService discountService, ILogger<gRPCdiscountService> logger, IMapper mapper)
        {
            this._discountService = discountService;
            this._logger = logger;
            _mapper = mapper;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var result = await _discountService.AddProductCoupon(_mapper.Map<Coupon>(request.Coupon));
            if (result)
                return request.Coupon;
            else
                throw new RpcException(status: new Status(StatusCode.Cancelled, $"Error while creating Discount"));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var discount = await _discountService.GetProductCoupon(request.ProductId);
            if (discount != null)
            {
                return _mapper.Map<CouponModel>(discount);
            }
            throw new RpcException(status: new Status(StatusCode.NotFound, $"No Discount found for ProdcutId {request.ProductId}"));

        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleteResult = await _discountService.DeleteCoupon(request.ProductId);
            if (deleteResult)
            {
                return new DeleteDiscountResponse()
                {
                    Success = deleteResult
                };
            }
            throw new RpcException(status: new Status(StatusCode.Cancelled, $"Cannot Delete Discount With Product ID : {request.ProductId}"));

        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var updateResult = await _discountService.UpdateProductCoupon(_mapper.Map<Coupon>(request.Coupon));
            if (updateResult)
                return request.Coupon;
            throw new RpcException(status: new Status(StatusCode.Cancelled, $"Failed to Delete Discount With Product ID : {request.Coupon.ProductId}"));

        }
    }
}
