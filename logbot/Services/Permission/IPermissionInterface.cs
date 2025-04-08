using logbot.Models;

namespace logbot.Services.PermissionService
{
    public interface IPermissionInterface
    {
        Task<ServiceResponse<List<PermissionModel>>> GetAllPermissions();
        Task<ServiceResponse<PermissionModel>> GetPermissionById(Guid id);
        Task<ServiceResponse<PermissionModel>> CreatePermission(PermissionModel permission);
        Task<ServiceResponse<PermissionModel>> UpdatePermission(Guid id, PermissionModel permission);
        Task<ServiceResponse<PermissionModel>> DeletePermission(Guid id);
    }
}
