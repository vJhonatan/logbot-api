using logbot.Models;

public interface IUserResponseInterface
{
    Task<ServiceResponse<List<UserResponseModel>>> GetAllUserResponses();
    Task<ServiceResponse<UserResponseModel>> GetUserResponseById(Guid id);
    Task<ServiceResponse<UserResponseModel>> CreateUserResponse(UserResponseModel response);
    Task<ServiceResponse<UserResponseModel>> UpdateUserResponse(Guid id, UserResponseModel updatedResponse);
    Task<ServiceResponse<UserResponseModel>> DeleteUserResponse(Guid id);
}
