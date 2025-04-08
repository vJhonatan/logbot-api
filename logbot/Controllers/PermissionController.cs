using logbot.Models;
using logbot.Services.PermissionService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionInterface _service;

        public PermissionController(IPermissionInterface permissionService)
        {
            _service = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PermissionModel>>>> GetAllPermissions()
        {
            return Ok(await _service.GetAllPermissions());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PermissionModel>>> GetPermissionById(Guid id)
        {
            var response = await _service.GetPermissionById(id);
            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PermissionModel>>> CreatePermission([FromBody] PermissionModel permission)
        {
            var response = await _service.CreatePermission(permission);
            return CreatedAtAction(nameof(GetPermissionById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<PermissionModel>>> UpdatePermission(Guid id, [FromBody] PermissionModel permission)
        {
            if (id != permission.Id)
                return BadRequest("O ID da URL não bate com o do corpo da requisição.");

            var response = await _service.UpdatePermission(id, permission);
            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<PermissionModel>>> DeletePermission(Guid id)
        {
            var response = await _service.DeletePermission(id);
            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }
    }
}
