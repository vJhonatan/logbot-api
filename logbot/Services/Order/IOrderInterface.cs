using logbot.Models;

namespace logbot.Services.OrderService
{
    public interface IOrderInterface
    {
        Task<ServiceResponse<List<OrderModel>>> GetAllOrders();
        Task<ServiceResponse<OrderModel>> GetOrderById(Guid id);
        Task<ServiceResponse<OrderModel>> CreateOrder(OrderModel order);
        Task<ServiceResponse<OrderModel>> UpdateOrder(Guid id, OrderModel updatedOrder);
        Task<ServiceResponse<OrderModel>> DeleteOrder(Guid id);
    }
}
