using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class OrderItemModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public OrderModel Order { get; set; }
        public Guid ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
