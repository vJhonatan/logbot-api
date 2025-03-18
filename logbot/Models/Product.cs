namespace logbot.Models
{
    public class Product
    {
        private Guid Id { get; set; }

        private Company CompanyId { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private double Price { get; set; }

        private string Category { get; set; }

        private bool Is_Available { get; set; }

        private DateTime CreatedAt { get; set; }

        private DateTime UpdatedAt { get; set; }
    }
}
