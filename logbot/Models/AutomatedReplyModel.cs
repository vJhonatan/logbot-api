using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class AutomatedReplyModel
    {
        [Key]
        public Guid Id { get; set; }
        public string TriggerMessage { get; set; }
        public string ReplyMessage { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public bool IsActive { get; set; }
    }
}
