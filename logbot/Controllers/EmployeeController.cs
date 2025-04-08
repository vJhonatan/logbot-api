using logbot.Models;
using logbot.Services.EmployeeService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _service;

        public EmployeeController(IEmployeeInterface employeeService)
        {
            _service = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
        {
            var response = await _service.GetEmployees();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployee([FromBody] EmployeeModel employee)
        {
            var response = await _service.CreateEmployee(employee);
            if (!response.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetEmployeeById), new { id = response.Data.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(Guid id)
        {
            var response = await _service.GetEmployeebyId(id);
            if (!response.Success || response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> DeleteEmployeeById(Guid id)
        {
            var response = await _service.DeleteEmployeeById(id);
            if (!response.Success || response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> UpdateEmployee(Guid id, [FromBody] EmployeeModel newEmployee)
        {
            if (id != newEmployee.Id)
                return BadRequest("O ID da URL não bate com o corpo da requisição.");

            var response = await _service.UpdateEmployee(id, newEmployee);

            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
