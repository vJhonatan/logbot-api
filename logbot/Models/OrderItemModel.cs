using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class OrderItemModel
    {
        [Key]
        public Guid Id { get; set; }
        public OrderModel OrderId { get; set; }
        public ProductModel ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
