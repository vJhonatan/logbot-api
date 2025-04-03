using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class ConversationModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
