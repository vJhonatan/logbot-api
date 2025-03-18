using logbot.Enums;

namespace logbot.Models
{
    public class ConversationLog
    {
        public Guid Id { get; set; }   
        public Employee EmployeeId { get; set; }
        public Company CompanyId { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public Conversation ConversationId { get; set; }
        public string MessageSent { get; set; }
        public string MessageReceived { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
