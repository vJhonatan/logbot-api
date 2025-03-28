using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class PaymentModel
    {
        [Key]
        public Guid Id { get; set; }
        public CompanyModel CompanyId { get; set; }
        public OrderModel OrderId { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
