using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class ConversationLogModel
    {
        [Key]
        public Guid Id { get; set; }   
        public EmployeeModel EmployeeId { get; set; }
        public CompanyModel CompanyId { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public ConversationModel ConversationId { get; set; }
        public string MessageSent { get; set; }
        public string MessageReceived { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
