using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.PermissionService
{
    public class PermissionService : IPermissionInterface
    {
        private readonly AppDbContext _context;

        public PermissionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<PermissionModel>>> GetAllPermissions()
        {
            var response = new ServiceResponse<List<PermissionModel>>();
            response.Data = await _context.Permissions.ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<PermissionModel>> GetPermissionById(Guid id)
        {
            var response = new ServiceResponse<PermissionModel>();
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
            {
                response.Success = false;
                response.Message = "Permissão não encontrada.";
                return response;
            }

            response.Data = permission;
            return response;
        }

        public async Task<ServiceResponse<PermissionModel>> CreatePermission(PermissionModel permission)
        {
            var response = new ServiceResponse<PermissionModel>();
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();

            response.Data = permission;
            response.Message = "Permissão criada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<PermissionModel>> UpdatePermission(Guid id, PermissionModel permission)
        {
            var response = new ServiceResponse<PermissionModel>();
            var dbPermission = await _context.Permissions.FindAsync(id);

            if (dbPermission == null)
            {
                response.Success = false;
                response.Message = "Permissão não encontrada.";
                return response;
            }

            dbPermission.Name = permission.Name;
            dbPermission.Description = permission.Description;

            _context.Entry(dbPermission).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = dbPermission;
            response.Message = "Permissão atualizada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<PermissionModel>> DeletePermission(Guid id)
        {
            var response = new ServiceResponse<PermissionModel>();
            var permission = await _context.Permissions.FindAsync(id);

            if (permission == null)
            {
                response.Success = false;
                response.Message = "Permissão não encontrada.";
                return response;
            }

            _context.Permissions.Remove(permission);
            await _context.SaveChangesAsync();

            response.Data = permission;
            response.Message = "Permissão removida com sucesso!";
            return response;
        }
    }
}
