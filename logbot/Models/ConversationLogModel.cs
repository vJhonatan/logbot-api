using logbot.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class ConversationLogModel
    {
        [Key]
        public Guid Id { get; set; }   
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public EmployeeModel? Employee { get; set; }
        public Guid CompanyId { get; set; }
        [JsonIgnore]
        public CompanyModel? Company { get; set; }
        public Guid ConversationId { get; set; }
        [JsonIgnore]
        public ConversationModel? Conversation { get; set; }
        public MessagePlatformEnum Platform { get; set; }
        public string MessageSent { get; set; }
        public string MessageReceived { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
