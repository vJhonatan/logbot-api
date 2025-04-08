using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class OrderItemModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public OrderModel? Order { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public ProductModel? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
