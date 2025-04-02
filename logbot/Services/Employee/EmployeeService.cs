using logbot.Database;
using logbot.Models;

namespace logbot.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly AppDbContext _context;

        public EmployeeService (AppDbContext context)
        {
            _context = context;
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeInterface.AddEmployee(EmployeeModel employee)
        {
            ServiceResponse<List<EmployeeModel>> response = new ServiceResponse<List<EmployeeModel>>();

            try
            {

            }
            catch (Exception ex) 
            { 
            }
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeInterface.DeleteEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeInterface.DesactivateEmployee(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeInterface.GetEmployeebyId(Guid id)
        {
            throw new NotImplementedException();
        }

        async Task<ServiceResponse<List<EmployeeModel>>> IEmployeeInterface.GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> response = new ServiceResponse<List<EmployeeModel>> ();

            try
            {
                response.Data = _context.Employees.ToList();
            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        async Task<ServiceResponse<EmployeeModel>> IEmployeeInterface.UpdateEmployee(EmployeeModel newEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
