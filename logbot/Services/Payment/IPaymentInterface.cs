using logbot.Models;

namespace logbot.Services.PaymentService
{
    public interface IPaymentInterface
    {
        Task<ServiceResponse<List<PaymentModel>>> GetAllPayments();
        Task<ServiceResponse<PaymentModel>> GetPaymentById(Guid id);
        Task<ServiceResponse<PaymentModel>> CreatePayment(PaymentModel payment);
        Task<ServiceResponse<PaymentModel>> UpdatePayment(Guid id, PaymentModel updatedPayment);
        Task<ServiceResponse<PaymentModel>> DeletePayment(Guid id);
    }
}
