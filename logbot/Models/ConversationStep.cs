using logbot.Enums;

namespace logbot.Models
{
    public class ConversationStep
    {
        public Guid Id { get; set; }
        public Conversation ConversationId { get; set; }
        public int StepOrder { get; set; }
        public string Message { get; set; }
        public ResponseTypeEnum ExpectedResponseType { get; set; }
        public Guid? NextStepId { get; set; }
        public string Action { get; set; }
    }
}
