using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class UserResponseModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ConversationId { get; set; }
        public ConversationModel Conversation { get; set; }
        public Guid ConversationStepId { get; set; }
        public ConversationStepModel ConversationStep { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public string ResponseContent { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
