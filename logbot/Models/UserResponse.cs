namespace logbot.Models
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public Conversation ConversationId { get; set; }
        public ConversationStep StepId { get; set; }
        public Employee EmployeeId { get; set; }
        public string ResponseContent { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
