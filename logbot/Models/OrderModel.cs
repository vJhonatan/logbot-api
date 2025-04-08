using logbot.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class OrderModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel? Company { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public OrderEnum OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}