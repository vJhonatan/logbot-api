using logbot.Models;
using logbot.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface employeeInterface;

        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            this.employeeInterface = employeeInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
        {
            return Ok(await employeeInterface.GetEmployees());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployee([FromBody] EmployeeModel employee)
        {
            return Ok(await employeeInterface.CreateEmployee(employee));
        }
    }
}
