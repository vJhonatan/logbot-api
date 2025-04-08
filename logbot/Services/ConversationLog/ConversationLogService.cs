using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.ConversationLogService
{
    public class ConversationLogService : IConversationLogInterface
    {
        private readonly AppDbContext _context;

        public ConversationLogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ConversationLogModel>>> GetAllLogs()
        {
            var response = new ServiceResponse<List<ConversationLogModel>>();
            response.Data = await _context.ConversationLogs
                .Include(c => c.Employee)
                .Include(c => c.Company)
                .Include(c => c.Conversation)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<ConversationLogModel>> GetLogById(Guid id)
        {
            var response = new ServiceResponse<ConversationLogModel>();
            var log = await _context.ConversationLogs
                .Include(c => c.Employee)
                .Include(c => c.Company)
                .Include(c => c.Conversation)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (log == null)
            {
                response.Success = false;
                response.Message = "Log de conversa não encontrado";
                return response;
            }

            response.Data = log;
            return response;
        }

        public async Task<ServiceResponse<ConversationLogModel>> CreateLog(ConversationLogModel log)
        {
            var response = new ServiceResponse<ConversationLogModel>();

            _context.ConversationLogs.Add(log);
            await _context.SaveChangesAsync();

            response.Message = "Log criado com sucesso!";
            response.Data = log;
            return response;
        }

        public async Task<ServiceResponse<ConversationLogModel>> UpdateLog(Guid id, ConversationLogModel updatedLog)
        {
            var response = new ServiceResponse<ConversationLogModel>();
            var log = await _context.ConversationLogs.FindAsync(id);

            if (log == null)
            {
                response.Success = false;
                response.Message = "Log não encontrado";
                return response;
            }

            log.EmployeeId = updatedLog.EmployeeId;
            log.CompanyId = updatedLog.CompanyId;
            log.ConversationId = updatedLog.ConversationId;
            log.MessageSent = updatedLog.MessageSent;
            log.MessageReceived = updatedLog.MessageReceived;
            log.Platform = updatedLog.Platform;
            log.Timestamp = updatedLog.Timestamp;

            _context.Entry(log).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = log;
            return response;
        }

        public async Task<ServiceResponse<ConversationLogModel>> DeleteLog(Guid id)
        {
            var response = new ServiceResponse<ConversationLogModel>();
            var log = await _context.ConversationLogs.FindAsync(id);

            if (log == null)
            {
                response.Success = false;
                response.Message = "Log não encontrado";
                return response;
            }

            _context.ConversationLogs.Remove(log);
            await _context.SaveChangesAsync();

            response.Data = log;
            return response;
        }
    }
}
