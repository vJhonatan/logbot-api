using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.PaymentService
{
    public class PaymentService : IPaymentInterface
    {
        private readonly AppDbContext _context;

        public PaymentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PaymentModel>>> GetAllPayments()
        {
            var response = new ServiceResponse<List<PaymentModel>>();
            response.Data = await _context.Payments
                .Include(p => p.Company)
                .Include(p => p.Order)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<PaymentModel>> GetPaymentById(Guid id)
        {
            var response = new ServiceResponse<PaymentModel>();
            var payment = await _context.Payments
                .Include(p => p.Company)
                .Include(p => p.Order)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (payment == null)
            {
                response.Success = false;
                response.Message = "Pagamento não encontrado";
                return response;
            }

            response.Data = payment;
            return response;
        }

        public async Task<ServiceResponse<PaymentModel>> CreatePayment(PaymentModel payment)
        {
            var response = new ServiceResponse<PaymentModel>();

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            response.Data = payment;
            response.Message = "Pagamento registrado com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<PaymentModel>> UpdatePayment(Guid id, PaymentModel updatedPayment)
        {
            var response = new ServiceResponse<PaymentModel>();
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                response.Success = false;
                response.Message = "Pagamento não encontrado";
                return response;
            }

            payment.CompanyId = updatedPayment.CompanyId;
            payment.OrderId = updatedPayment.OrderId;
            payment.PaymentMethod = updatedPayment.PaymentMethod;
            payment.Amount = updatedPayment.Amount;
            payment.PaymentStatus = updatedPayment.PaymentStatus;
            payment.PaymentDate = updatedPayment.PaymentDate;

            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = payment;
            return response;
        }

        public async Task<ServiceResponse<PaymentModel>> DeletePayment(Guid id)
        {
            var response = new ServiceResponse<PaymentModel>();
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                response.Success = false;
                response.Message = "Pagamento não encontrado";
                return response;
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            response.Data = payment;
            return response;
        }
    }
}
