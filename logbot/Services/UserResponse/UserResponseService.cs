using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.UserResponseService
{
    public class UserResponseService : IUserResponseInterface
    {
        private readonly AppDbContext _context;

        public UserResponseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<UserResponseModel>>> GetAllUserResponses()
        {
            var response = new ServiceResponse<List<UserResponseModel>>();
            response.Data = await _context.UserResponses
                .Include(x => x.Conversation)
                .Include(x => x.ConversationStep)
                .Include(x => x.Employee)
                .ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<UserResponseModel>> GetUserResponseById(Guid id)
        {
            var response = new ServiceResponse<UserResponseModel>();
            var data = await _context.UserResponses
                .Include(x => x.Conversation)
                .Include(x => x.ConversationStep)
                .Include(x => x.Employee)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (data == null)
            {
                response.Success = false;
                response.Message = "Resposta do usuário não encontrada";
                return response;
            }

            response.Data = data;
            return response;
        }

        public async Task<ServiceResponse<UserResponseModel>> CreateUserResponse(UserResponseModel responseModel)
        {
            var response = new ServiceResponse<UserResponseModel>();

            _context.UserResponses.Add(responseModel);
            await _context.SaveChangesAsync();

            response.Data = responseModel;
            response.Message = "Resposta criada com sucesso!";
            response.Success = true;

            return response;
        }

        public async Task<ServiceResponse<UserResponseModel>> UpdateUserResponse(Guid id, UserResponseModel updatedResponse)
        {
            var response = new ServiceResponse<UserResponseModel>();
            var responseModel = await _context.UserResponses.FindAsync(id);

            if (responseModel == null)
            {
                response.Success = false;
                response.Message = "Resposta não encontrada";
                return response;
            }

            responseModel.ConversationId = updatedResponse.ConversationId;
            responseModel.ConversationStepId = updatedResponse.ConversationStepId;
            responseModel.EmployeeId = updatedResponse.EmployeeId;
            responseModel.ResponseContent = updatedResponse.ResponseContent;
            responseModel.ReceivedAt = updatedResponse.ReceivedAt;

            _context.Entry(responseModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = responseModel;
            response.Message = "Resposta atualizada com sucesso!";
            response.Success = true;

            return response;
        }

        public async Task<ServiceResponse<UserResponseModel>> DeleteUserResponse(Guid id)
        {
            var response = new ServiceResponse<UserResponseModel>();
            var responseModel = await _context.UserResponses.FindAsync(id);

            if (responseModel == null)
            {
                response.Success = false;
                response.Message = "Resposta não encontrada";
                return response;
            }

            _context.UserResponses.Remove(responseModel);
            await _context.SaveChangesAsync();

            response.Data = responseModel;
            response.Message = "Resposta deletada com sucesso!";
            response.Success = true;

            return response;
        }
    }
}
