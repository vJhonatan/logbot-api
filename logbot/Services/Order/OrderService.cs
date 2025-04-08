using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.OrderService
{
    public class OrderService : IOrderInterface
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<OrderModel>>> GetAllOrders()
        {
            var response = new ServiceResponse<List<OrderModel>>();
            response.Data = await _context.Orders
                .Include(o => o.Company)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<OrderModel>> GetOrderById(Guid id)
        {
            var response = new ServiceResponse<OrderModel>();
            var order = await _context.Orders
                .Include(o => o.Company)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                response.Success = false;
                response.Message = "Pedido não encontrado.";
                return response;
            }

            response.Data = order;
            return response;
        }

        public async Task<ServiceResponse<OrderModel>> CreateOrder(OrderModel order)
        {
            var response = new ServiceResponse<OrderModel>();

            var company = await _context.Companies.FindAsync(order.CompanyId);
            if (company == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada.";
                return response;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            response.Data = order;
            response.Message = "Pedido criado com sucesso.";
            return response;
        }

        public async Task<ServiceResponse<OrderModel>> UpdateOrder(Guid id, OrderModel updatedOrder)
        {
            var response = new ServiceResponse<OrderModel>();
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                response.Success = false;
                response.Message = "Pedido não encontrado.";
                return response;
            }

            order.CustomerName = updatedOrder.CustomerName;
            order.CustomerPhone = updatedOrder.CustomerPhone;
            order.OrderStatus = updatedOrder.OrderStatus;
            order.TotalPrice = updatedOrder.TotalPrice;
            order.PaymentStatus = updatedOrder.PaymentStatus;
            order.UpdatedAt = DateTime.UtcNow;

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = order;
            return response;
        }

        public async Task<ServiceResponse<OrderModel>> DeleteOrder(Guid id)
        {
            var response = new ServiceResponse<OrderModel>();
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                response.Success = false;
                response.Message = "Pedido não encontrado.";
                return response;
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            response.Data = order;
            response.Message = "Pedido removido com sucesso.";
            return response;
        }
    }
}
