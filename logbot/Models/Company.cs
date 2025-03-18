namespace logbot.Models
{
    public class Company
    {
        private Guid Id { get; set; }

        private string Name { get; set; }

        private string Description { get; set; }

        private string Email { get; set; }

        private string Phone { get; set; }

        private string Address { get; set; }

        private DateTime CreatedAt { get; set; }

        private DateTime UpdatedAt { get; set; }

        private bool IsActive { get; set; }
    }
}
