using logbot.Models;

namespace logbot.Services.EmployeeService
{
    public interface IEmployeeInterface
    {
        public Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
        public Task<ServiceResponse<EmployeeModel>> CreateEmployee(EmployeeModel employee);
        public Task<ServiceResponse<EmployeeModel>> GetEmployeebyId(Guid id);
        public Task<ServiceResponse<EmployeeModel>> UpdateEmployee(Guid id,EmployeeModel newEmployee);
        public Task<ServiceResponse<EmployeeModel>> DeleteEmployeeById(Guid id);
    }
}
