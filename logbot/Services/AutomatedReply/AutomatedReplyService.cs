using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

public class AutomatedReplyService : IAutomatedReplyInterface
{
    private readonly AppDbContext _context;

    public AutomatedReplyService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<AutomatedReplyModel>>> GetAllReplies()
    {
        var response = new ServiceResponse<List<AutomatedReplyModel>>();
        response.Data = await _context.AutomatedReplies.ToListAsync();
        return response;
    }

    public async Task<ServiceResponse<AutomatedReplyModel>> GetReplyById(Guid id)
    {
        var response = new ServiceResponse<AutomatedReplyModel>();
        var reply = await _context.AutomatedReplies.FindAsync(id);

        if (reply == null)
        {
            response.Success = false;
            response.Message = "Resposta automática não encontrada.";
            return response;
        }

        response.Data = reply;
        return response;
    }

    public async Task<ServiceResponse<AutomatedReplyModel>> CreateReply(AutomatedReplyModel reply)
    {
        var response = new ServiceResponse<AutomatedReplyModel>();

        _context.AutomatedReplies.Add(reply);
        await _context.SaveChangesAsync();

        response.Data = reply;
        response.Message = "Resposta automática criada com sucesso!";
        return response;
    }

    public async Task<ServiceResponse<AutomatedReplyModel>> UpdateReply(Guid id, AutomatedReplyModel updatedReply)
    {
        var response = new ServiceResponse<AutomatedReplyModel>();
        var reply = await _context.AutomatedReplies.FindAsync(id);

        if (reply == null)
        {
            response.Success = false;
            response.Message = "Resposta automática não encontrada.";
            return response;
        }

        reply.TriggerMessage = updatedReply.TriggerMessage;
        reply.ReplyMessage = updatedReply.ReplyMessage;
        reply.Platform = updatedReply.Platform;
        reply.IsActive = updatedReply.IsActive;

        _context.Entry(reply).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        response.Data = reply;
        response.Message = "Resposta automática atualizada com sucesso!";
        return response;
    }

    public async Task<ServiceResponse<AutomatedReplyModel>> DeleteReply(Guid id)
    {
        var response = new ServiceResponse<AutomatedReplyModel>();
        var reply = await _context.AutomatedReplies.FindAsync(id);

        if (reply == null)
        {
            response.Success = false;
            response.Message = "Resposta automática não encontrada.";
            return response;
        }

        _context.AutomatedReplies.Remove(reply);
        await _context.SaveChangesAsync();

        response.Data = reply;
        response.Message = "Resposta automática deletada com sucesso!";
        return response;
    }
}
