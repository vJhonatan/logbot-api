namespace logbot.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
