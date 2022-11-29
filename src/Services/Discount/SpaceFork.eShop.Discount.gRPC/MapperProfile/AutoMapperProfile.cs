using AutoMapper;
using SpaceFork.eShop.Discount.Core.Entity;
using SpaceFork.eShop.Discount.gRPC.Protos;

namespace SpaceFork.eShop.Discount.gRPC.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CouponModel, Coupon>().ReverseMap();
        }
    }
}
