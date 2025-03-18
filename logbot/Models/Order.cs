using logbot.Enums;

namespace logbot.Models
{
    public class Order
    {
        private Guid Id { get; set; }
        private Company CompanyId { get; set; }
        private string Customer_name { get; set; }
        private string Customer_phone { get; set; }
        private OrderEnum OrderStatus { get; set; }
        private decimal TotalPrice { get; set; }
        private PaymentStatusEnum PaymentStatus { get; set; }
        private DateTime CreatedAt { get; set; }
        private DateTime UpdatedAt { get; set; }
    }
}
