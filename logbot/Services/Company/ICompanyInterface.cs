using logbot.Models;

namespace logbot.Services.CompanyService
{
    public interface ICompanyInterface
    {
        Task<ServiceResponse<List<CompanyModel>>> GetAllCompanies();
        Task<ServiceResponse<CompanyModel>> GetCompanyById(Guid id);
        Task<ServiceResponse<CompanyModel>> CreateCompany(CompanyModel company);
        Task<ServiceResponse<CompanyModel>> UpdateCompany(Guid id, CompanyModel company);
        Task<ServiceResponse<CompanyModel>> DeleteCompany(Guid id);
    }
}
