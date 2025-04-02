using logbot.Models;

namespace logbot.Services.EmployeeService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
        Task<ServiceResponse<EmployeeModel>> AddEmployee(EmployeeModel employee);
        Task<ServiceResponse<EmployeeModel>> GetEmployeebyId(Guid id);
        Task<ServiceResponse<EmployeeModel>> UpdateEmployee(EmployeeModel newEmployee);
        Task<ServiceResponse<EmployeeModel>> DeleteEmployeeById(Guid id);
        Task<ServiceResponse<EmployeeModel>> DesactivateEmployee(Guid id);
    }
}
