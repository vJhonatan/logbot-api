using logbot.Models;

public interface IAutomatedReplyInterface
{
    Task<ServiceResponse<List<AutomatedReplyModel>>> GetAllReplies();
    Task<ServiceResponse<AutomatedReplyModel>> GetReplyById(Guid id);
    Task<ServiceResponse<AutomatedReplyModel>> CreateReply(AutomatedReplyModel reply);
    Task<ServiceResponse<AutomatedReplyModel>> UpdateReply(Guid id, AutomatedReplyModel updatedReply);
    Task<ServiceResponse<AutomatedReplyModel>> DeleteReply(Guid id);
}
