using logbot.Enums;

namespace logbot.Models
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Company CompanyId { get; set; }
        public Order OrderId { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
