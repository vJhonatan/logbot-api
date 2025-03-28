using System.ComponentModel.DataAnnotations;

namespace logbot.Models
{
    public class UserResponseModel
    {
        [Key]
        public Guid Id { get; set; }
        public ConversationModel ConversationId { get; set; }
        public ConversationStepModel StepId { get; set; }
        public EmployeeModel EmployeeId { get; set; }
        public string ResponseContent { get; set; }
        public DateTime ReceivedAt { get; set; }
    }
}
