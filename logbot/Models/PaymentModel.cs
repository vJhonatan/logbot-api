using logbot.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class PaymentModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel? Company { get; set; }
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public OrderModel? Order { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
