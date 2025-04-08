using logbot.Models;

namespace logbot.Services.ConversationLogService
{
    public interface IConversationLogInterface
    {
        Task<ServiceResponse<List<ConversationLogModel>>> GetAllLogs();
        Task<ServiceResponse<ConversationLogModel>> GetLogById(Guid id);
        Task<ServiceResponse<ConversationLogModel>> CreateLog(ConversationLogModel log);
        Task<ServiceResponse<ConversationLogModel>> UpdateLog(Guid id, ConversationLogModel updatedLog);
        Task<ServiceResponse<ConversationLogModel>> DeleteLog(Guid id);
    }
}
