using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly AppDbContext _context;

        public EmployeeService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<EmployeeModel>> CreateEmployee(EmployeeModel employee)
        {
            ServiceResponse<EmployeeModel> response = new ServiceResponse<EmployeeModel>();

            try
            {
                if (employee == null)
                {
                    response.Message = "Insira os dados do funcionário.";
                    response.Success = false;
                    return response;
                }

                // Busca a empresa pelo ID no banco para evitar tentativa de inserção
                var existingCompany = await _context.Companies.FindAsync(employee.CompanyId);
                if (existingCompany == null)
                {
                    response.Message = "A empresa informada não existe.";
                    response.Success = false;
                    return response;
                }

                // Remove qualquer referência desnecessária ao objeto Company para evitar conflitos
                employee.Company = null;

                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                response.Data = employee;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException?.Message ?? ex.Message;
                response.Success = false;
            }

            return response;
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
