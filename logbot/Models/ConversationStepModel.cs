using logbot.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace logbot.Models
{
    public class ConversationStepModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        [JsonIgnore]
        public ConversationModel? Conversation { get; set; }
        public int StepOrder { get; set; }
        public string Message { get; set; }
        public ResponseTypeEnum ExpectedResponseType { get; set; }
        public Guid? NextStepId { get; set; }
        public string Action { get; set; }
    }
}
