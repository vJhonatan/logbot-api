using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            var response = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                response.Data = await _context.Employees.Include(e => e.Company).ToListAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<EmployeeModel>> CreateEmployee(EmployeeModel employee)
        {
            var response = new ServiceResponse<EmployeeModel>();

            var validation = ValidateEmployeeModel(employee);

            if (validation != null)
            {
                response.Success = false;
                response.Message = validation;
                return response;
            }

            var existingCompany = await _context.Companies.FindAsync(employee.CompanyId);

            if (existingCompany == null)
            {
                response.Success = false;
                response.Message = "A empresa informada não existe.";
                return response;
            }

            var emailExists = await _context.Employees.AnyAsync(e => e.Email == employee.Email);

            if (emailExists)
            {
                response.Success = false;
                response.Message = "Já existe um funcionário com este e-mail.";
                return response;
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var employeeWithCompany = await _context.Employees
                .Include(e => e.Company)
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            response.Data = employeeWithCompany;
            response.Success = true;
            response.Message = "Funcionário criado com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeebyId(Guid id)
        {
            var response = new ServiceResponse<EmployeeModel>();

            var employee = await _context.Employees
                .Include(e => e.Company)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                response.Success = false;
                response.Message = "Funcionário não encontrado.";
                return response;
            }

            response.Data = employee;
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<EmployeeModel>> DeleteEmployeeById(Guid id)
        {
            var response = new ServiceResponse<EmployeeModel>();

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                response.Success = false;
                response.Message = "Funcionário não encontrado";
                return response;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            response.Data = employee;
            response.Success = true;
            response.Message = "Funcionário deletado com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<EmployeeModel>> UpdateEmployee(Guid id, EmployeeModel newEmployee)
        {
            var response = new ServiceResponse<EmployeeModel>();

            var validation = ValidateEmployeeModel(newEmployee);
            if (validation != null)
            {
                response.Success = false;
                response.Message = validation;
                return response;
            }

            var employee = await _context.Employees
                .Include(e => e.Company)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                response.Success = false;
                response.Message = "Funcionário não encontrado";
                return response;
            }

            var emailExists = await _context.Employees
                .AnyAsync(e => e.Email == newEmployee.Email && e.Id != id);

            if (emailExists)
            {
                response.Success = false;
                response.Message = "Este e-mail já está sendo usado por outro funcionário.";
                return response;
            }

            employee.Name = newEmployee.Name;
            employee.Email = newEmployee.Email;
            employee.Phone = newEmployee.Phone;
            employee.Role = newEmployee.Role;
            employee.Permissions = newEmployee.Permissions;
            employee.Status = newEmployee.Status;

            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = employee;
            response.Success = true;
            response.Message = "Funcionário atualizado com sucesso!";
            return response;
        }

        private string? ValidateEmployeeModel(EmployeeModel employee)
        {
            if (employee == null) return "Dados do funcionário não informados.";
            if (string.IsNullOrWhiteSpace(employee.Name)) return "Nome é obrigatório.";
            if (string.IsNullOrWhiteSpace(employee.Email)) return "E-mail é obrigatório.";
            if (string.IsNullOrWhiteSpace(employee.Phone)) return "Telefone é obrigatório.";
            return null;
        }
    }
}
