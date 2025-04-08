using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.MessageService
{
    public class MessageService : IMessageInterface
    {
        private readonly AppDbContext _context;

        public MessageService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MessageModel>>> GetAllMessages()
        {
            var response = new ServiceResponse<List<MessageModel>>();
            response.Data = await _context.Messages
                .Include(m => m.Company)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<MessageModel>> GetMessageById(Guid id)
        {
            var response = new ServiceResponse<MessageModel>();
            var message = await _context.Messages
                .Include(m => m.Company)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (message == null)
            {
                response.Success = false;
                response.Message = "Mensagem não encontrada";
                return response;
            }

            response.Data = message;
            return response;
        }

        public async Task<ServiceResponse<MessageModel>> CreateMessage(MessageModel message)
        {
            var response = new ServiceResponse<MessageModel>();

            var company = await _context.Companies.FindAsync(message.CompanyId);
            if (company == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada";
                return response;
            }

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            var messageWithCompany = await _context.Messages
                .Include(m => m.Company)
                .FirstOrDefaultAsync(m => m.Id == message.Id);

            response.Data = messageWithCompany;
            response.Message = "Mensagem criada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<MessageModel>> UpdateMessage(Guid id, MessageModel updatedMessage)
        {
            var response = new ServiceResponse<MessageModel>();
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                response.Success = false;
                response.Message = "Mensagem não encontrada";
                return response;
            }

            message.CompanyId = updatedMessage.CompanyId;
            message.Platform = updatedMessage.Platform;
            message.SenderName = updatedMessage.SenderName;
            message.SenderId = updatedMessage.SenderId;
            message.MessageContent = updatedMessage.MessageContent;
            message.ReceivedAt = updatedMessage.ReceivedAt;
            message.Responded = updatedMessage.Responded;

            _context.Entry(message).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = message;
            response.Message = "Mensagem atualizada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<MessageModel>> DeleteMessage(Guid id)
        {
            var response = new ServiceResponse<MessageModel>();
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                response.Success = false;
                response.Message = "Mensagem não encontrada";
                return response;
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            response.Data = message;
            response.Message = "Mensagem deletada com sucesso!";
            return response;
        }
    }
}
