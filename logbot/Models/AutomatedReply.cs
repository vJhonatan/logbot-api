using logbot.Enums;

namespace logbot.Models
{
    public class AutomatedReply
    {
        public Guid Id { get; set; }
        public string TriggerMessage { get; set; }
        public string ReplyMessage { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public bool IsActive { get; set; }
    }
}
