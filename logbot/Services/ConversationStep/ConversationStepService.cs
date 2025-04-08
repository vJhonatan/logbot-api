using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.ConversationStepService
{
    public class ConversationStepService : IConversationStepInterface
    {
        private readonly AppDbContext _context;

        public ConversationStepService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ConversationStepModel>>> GetAllConversationSteps()
        {
            var response = new ServiceResponse<List<ConversationStepModel>>();
            response.Data = await _context.ConversationSteps
                .Include(s => s.Conversation)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<ConversationStepModel>> GetConversationStepById(Guid id)
        {
            var response = new ServiceResponse<ConversationStepModel>();
            var step = await _context.ConversationSteps
                .Include(s => s.Conversation)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (step == null)
            {
                response.Success = false;
                response.Message = "Etapa de conversa não encontrada.";
                return response;
            }

            response.Data = step;
            return response;
        }

        public async Task<ServiceResponse<ConversationStepModel>> CreateConversationStep(ConversationStepModel step)
        {
            var response = new ServiceResponse<ConversationStepModel>();

            _context.ConversationSteps.Add(step);
            await _context.SaveChangesAsync();

            response.Data = step;
            response.Message = "Etapa de conversa criada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<ConversationStepModel>> UpdateConversationStep(Guid id, ConversationStepModel updatedStep)
        {
            var response = new ServiceResponse<ConversationStepModel>();
            var step = await _context.ConversationSteps.FindAsync(id);

            if (step == null)
            {
                response.Success = false;
                response.Message = "Etapa de conversa não encontrada.";
                return response;
            }

            step.ConversationId = updatedStep.ConversationId;
            step.StepOrder = updatedStep.StepOrder;
            step.Message = updatedStep.Message;
            step.ExpectedResponseType = updatedStep.ExpectedResponseType;
            step.NextStepId = updatedStep.NextStepId;
            step.Action = updatedStep.Action;

            _context.Entry(step).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = step;
            return response;
        }

        public async Task<ServiceResponse<ConversationStepModel>> DeleteConversationStep(Guid id)
        {
            var response = new ServiceResponse<ConversationStepModel>();
            var step = await _context.ConversationSteps.FindAsync(id);

            if (step == null)
            {
                response.Success = false;
                response.Message = "Etapa de conversa não encontrada.";
                return response;
            }

            _context.ConversationSteps.Remove(step);
            await _context.SaveChangesAsync();

            response.Data = step;
            return response;
        }
    }
}
