using logbot.Models;

public interface IMessageInterface
{
    Task<ServiceResponse<List<MessageModel>>> GetAllMessages();
    Task<ServiceResponse<MessageModel>> GetMessageById(Guid id);
    Task<ServiceResponse<MessageModel>> CreateMessage(MessageModel message);
    Task<ServiceResponse<MessageModel>> UpdateMessage(Guid id, MessageModel updatedMessage);
    Task<ServiceResponse<MessageModel>> DeleteMessage(Guid id);
}
