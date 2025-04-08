using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.CompanyService
{
    public class CompanyService : ICompanyInterface
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CompanyModel>>> GetAllCompanies()
        {
            var response = new ServiceResponse<List<CompanyModel>>();

            try
            {
                response.Data = await _context.Companies.ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<CompanyModel>> GetCompanyById(Guid id)
        {
            var response = new ServiceResponse<CompanyModel>();
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada.";
                return response;
            }

            response.Data = company;
            return response;
        }

        public async Task<ServiceResponse<CompanyModel>> CreateCompany(CompanyModel company)
        {
            var response = new ServiceResponse<CompanyModel>();

            try
            {
                company.CreatedAt = DateTime.UtcNow;
                company.UpdatedAt = DateTime.UtcNow;
                company.IsActive = true;

                _context.Companies.Add(company);
                await _context.SaveChangesAsync();

                response.Message = "Empresa criada com sucesso!";
                response.Data = company;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<CompanyModel>> UpdateCompany(Guid id, CompanyModel company)
        {
            var response = new ServiceResponse<CompanyModel>();
            var existing = await _context.Companies.FindAsync(id);

            if (existing == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada.";
                return response;
            }

            existing.Name = company.Name;
            existing.Description = company.Description;
            existing.Email = company.Email;
            existing.Phone = company.Phone;
            existing.Address = company.Address;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.IsActive = company.IsActive;

            _context.Entry(existing).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = existing;
            response.Message = "Empresa atualizada com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<CompanyModel>> DeleteCompany(Guid id)
        {
            var response = new ServiceResponse<CompanyModel>();
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada.";
                return response;
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            response.Data = company;
            response.Message = "Empresa deletada com sucesso!";
            return response;
        }
    }
}
