using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class ConversationLogModel
    {
        [Key]
        public Guid Id { get; set; }   
        public Guid EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyModel Company { get; set; }
        public Guid ConversationId { get; set; }
        public ConversationModel Conversation { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public string MessageSent { get; set; }
        public string MessageReceived { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
