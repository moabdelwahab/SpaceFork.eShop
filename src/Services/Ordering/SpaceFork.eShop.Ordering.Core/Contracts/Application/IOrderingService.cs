using SpaceFork.eShop.Ordering.Core.DataToTransfer.Requests;

namespace SpaceFork.eShop.Ordering.Core.Contracts.Application
{
    public interface IOrderingService
    {
        Task<List<DataToTransfer.ViewModels.Order>> GetOrdersOfUser(string username);
        Task<bool> UpdateOrder(UpdateOrderRequest updateOrderRequest);
        Task<bool> DeleteOrder(int orderId);
        Task<int> CreateOrder(CheckOutOrderRequest checkOutOrderRequest);

    }
}
