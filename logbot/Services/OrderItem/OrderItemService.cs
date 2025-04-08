using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

public class OrderItemService : IOrderItemInterface
{
    private readonly AppDbContext _context;

    public OrderItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<OrderItemModel>>> GetAllOrderItems()
    {
        var response = new ServiceResponse<List<OrderItemModel>>();
        response.Data = await _context.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Product)
            .ToListAsync();
        return response;
    }

    public async Task<ServiceResponse<OrderItemModel>> GetOrderItemById(Guid id)
    {
        var response = new ServiceResponse<OrderItemModel>();
        var item = await _context.OrderItems
            .Include(o => o.Order)
            .Include(o => o.Product)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
        {
            response.Success = false;
            response.Message = "Item do pedido não encontrado";
            return response;
        }

        response.Data = item;
        return response;
    }

    public async Task<ServiceResponse<OrderItemModel>> CreateOrderItem(OrderItemModel item)
    {
        var response = new ServiceResponse<OrderItemModel>();

        _context.OrderItems.Add(item);
        await _context.SaveChangesAsync();

        response.Data = item;
        response.Message = "Item criado com sucesso!";
        return response;
    }

    public async Task<ServiceResponse<OrderItemModel>> UpdateOrderItem(Guid id, OrderItemModel updatedItem)
    {
        var response = new ServiceResponse<OrderItemModel>();
        var item = await _context.OrderItems.FindAsync(id);

        if (item == null)
        {
            response.Success = false;
            response.Message = "Item não encontrado";
            return response;
        }

        item.OrderId = updatedItem.OrderId;
        item.ProductId = updatedItem.ProductId;
        item.Quantity = updatedItem.Quantity;
        item.Price = updatedItem.Price;

        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        response.Data = item;
        return response;
    }

    public async Task<ServiceResponse<OrderItemModel>> DeleteOrderItem(Guid id)
    {
        var response = new ServiceResponse<OrderItemModel>();
        var item = await _context.OrderItems.FindAsync(id);

        if (item == null)
        {
            response.Success = false;
            response.Message = "Item não encontrado";
            return response;
        }

        _context.OrderItems.Remove(item);
        await _context.SaveChangesAsync();

        response.Data = item;
        return response;
    }
}
