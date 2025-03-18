using logbot.Enums;

namespace logbot.Models
{
    public class Message
    {
        public Guid Id { get; set; } 
        public Company CompanyId { get; set; } 
        public MessagePlatformEnum Platform { get; set; } 
        public string SenderName { get; set; }
        public string SenderId { get; set; } 
        public string MessageContent { get; set; } 
        public DateTime ReceivedAt { get; set; }
        public bool Responded { get; set; }
    }
}
