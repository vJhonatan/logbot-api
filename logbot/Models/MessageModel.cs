using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class MessageModel
    {
        [Key]
        public Guid Id { get; set; } 
        public CompanyModel CompanyId { get; set; } 
        public MessagePlatformEnum Platform { get; set; } 
        public string SenderName { get; set; }
        public string SenderId { get; set; } 
        public string MessageContent { get; set; } 
        public DateTime ReceivedAt { get; set; }
        public bool Responded { get; set; }
    }
}
