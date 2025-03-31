using logbot.Models;
using logbot.Services;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [Controller]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {   
        private readonly EmployeeService _employeeService;
        
        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult newEmployee([FromBody] EmployeeModel employee)
        {
            _employeeService.newEmployee(employee);
            return Ok(new { message = "Funcionário adicionado!"});
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

    }
}
