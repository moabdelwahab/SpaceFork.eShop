using AutoMapper;
using SpaceFork.eShop.EventBus.Messages.Events;
using SpaceFork.eShop.Ordering.Application.Features.Orders.CheckoutOrder;
using SpaceFork.eShop.Ordering.Application.Features.Orders.UpdateOrder;
using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;
using SpaceFork.eShop.Ordering.Core.Domain.Entity;
using OrderVM = SpaceFork.eShop.Ordering.Core.DataToTransfer.ViewModels.Order;
namespace SpaceFork.eShop.Ordering.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderVM>().ReverseMap();
            CreateMap<CheckOutOrderRequest, Order>().ReverseMap();
            CreateMap<UpdateOrderRequest, Order>().ReverseMap();
            CreateMap<BasketCheckoutEvent, CheckOutOrderRequest>().ReverseMap();

        }
    }
}
