using logbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class ConversationStepModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public ConversationModel Conversation { get; set; }
        public int StepOrder { get; set; }
        public string Message { get; set; }
        public ResponseTypeEnum ExpectedResponseType { get; set; }
        public Guid? NextStepId { get; set; }
        public string Action { get; set; }
    }
}
