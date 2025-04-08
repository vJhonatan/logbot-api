using logbot.Models;

namespace logbot.Services.ConversationService
{
    public interface IConversationInterface
    {
        Task<ServiceResponse<List<ConversationModel>>> GetAllConversations();
        Task<ServiceResponse<ConversationModel>> GetConversationById(Guid id);
        Task<ServiceResponse<ConversationModel>> CreateConversation(ConversationModel conversation);
        Task<ServiceResponse<ConversationModel>> UpdateConversation(Guid id, ConversationModel updatedConversation);
        Task<ServiceResponse<ConversationModel>> DeleteConversation(Guid id);
    }
}
