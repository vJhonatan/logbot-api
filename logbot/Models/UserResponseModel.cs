using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class UserResponseModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        [JsonIgnore]
        public ConversationModel? Conversation { get; set; }
        public Guid ConversationStepId { get; set; }
        [JsonIgnore]
        public ConversationStepModel? ConversationStep { get; set; }
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public EmployeeModel? Employee { get; set; }
        public string ResponseContent { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
