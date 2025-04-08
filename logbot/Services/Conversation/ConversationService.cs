using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.ConversationService
{
    public class ConversationService : IConversationInterface
    {
        private readonly AppDbContext _context;

        public ConversationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ConversationModel>>> GetAllConversations()
        {
            var response = new ServiceResponse<List<ConversationModel>>();
            response.Data = await _context.Conversations.Include(c => c.Company).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<ConversationModel>> GetConversationById(Guid id)
        {
            var response = new ServiceResponse<ConversationModel>();
            var conversation = await _context.Conversations
                .Include(c => c.Company)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (conversation == null)
            {
                response.Success = false;
                response.Message = "Conversa não encontrada";
                return response;
            }

            response.Data = conversation;
            return response;
        }

        public async Task<ServiceResponse<ConversationModel>> CreateConversation(ConversationModel conversation)
        {
            var response = new ServiceResponse<ConversationModel>();

            _context.Conversations.Add(conversation);
            await _context.SaveChangesAsync();

            response.Message = "Conversa criada com sucesso!";
            response.Data = conversation;
            return response;
        }

        public async Task<ServiceResponse<ConversationModel>> UpdateConversation(Guid id, ConversationModel updatedConversation)
        {
            var response = new ServiceResponse<ConversationModel>();
            var conversation = await _context.Conversations.FindAsync(id);

            if (conversation == null)
            {
                response.Success = false;
                response.Message = "Conversa não encontrada";
                return response;
            }

            conversation.Name = updatedConversation.Name;
            conversation.Description = updatedConversation.Description;
            conversation.IsActive = updatedConversation.IsActive;
            conversation.CompanyId = updatedConversation.CompanyId;
            conversation.UpdatedAt = updatedConversation.UpdatedAt;

            _context.Entry(conversation).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = conversation;
            return response;
        }

        public async Task<ServiceResponse<ConversationModel>> DeleteConversation(Guid id)
        {
            var response = new ServiceResponse<ConversationModel>();
            var conversation = await _context.Conversations.FindAsync(id);

            if (conversation == null)
            {
                response.Success = false;
                response.Message = "Conversa não encontrada";
                return response;
            }

            _context.Conversations.Remove(conversation);
            await _context.SaveChangesAsync();

            response.Data = conversation;
            return response;
        }
    }
}
