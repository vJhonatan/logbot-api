using logbot.Models;

public interface IOrderItemInterface
{
    Task<ServiceResponse<List<OrderItemModel>>> GetAllOrderItems();
    Task<ServiceResponse<OrderItemModel>> GetOrderItemById(Guid id);
    Task<ServiceResponse<OrderItemModel>> CreateOrderItem(OrderItemModel item);
    Task<ServiceResponse<OrderItemModel>> UpdateOrderItem(Guid id, OrderItemModel updatedItem);
    Task<ServiceResponse<OrderItemModel>> DeleteOrderItem(Guid id);
}
