using logbot.Models;

namespace logbot.Services.ConversationStepService
{
    public interface IConversationStepInterface
    {
        Task<ServiceResponse<List<ConversationStepModel>>> GetAllConversationSteps();
        Task<ServiceResponse<ConversationStepModel>> GetConversationStepById(Guid id);
        Task<ServiceResponse<ConversationStepModel>> CreateConversationStep(ConversationStepModel step);
        Task<ServiceResponse<ConversationStepModel>> UpdateConversationStep(Guid id, ConversationStepModel step);
        Task<ServiceResponse<ConversationStepModel>> DeleteConversationStep(Guid id);
    }
}
