using logbot.Models;
using logbot.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInterface _service;

        public CompanyController(ICompanyInterface companyService)
        {
            _service = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CompanyModel>>>> GetAllCompanies()
        {
            return Ok(await _service.GetAllCompanies());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CompanyModel>>> GetCompanyById(Guid id)
        {
            var response = await _service.GetCompanyById(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CompanyModel>>> CreateCompany([FromBody] CompanyModel company)
        {
            var response = await _service.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompanyById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<CompanyModel>>> UpdateCompany(Guid id, [FromBody] CompanyModel company)
        {
            if (id != company.Id)
                return BadRequest("O ID da URL não bate com o corpo da requisição.");

            var response = await _service.UpdateCompany(id, company);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<CompanyModel>>> DeleteCompany(Guid id)
        {
            var response = await _service.DeleteCompany(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }
    }
}
