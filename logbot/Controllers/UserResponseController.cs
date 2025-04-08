using logbot.Models;
using logbot.Services.UserResponseService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserResponseController : ControllerBase
    {
        private readonly IUserResponseInterface _service;

        public UserResponseController(IUserResponseInterface userResponseService)
        {
            _service = userResponseService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserResponseModel>>>> GetAllUserResponses()
        {
            return Ok(await _service.GetAllUserResponses());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserResponseModel>>> GetUserResponseById(Guid id)
        {
            var response = await _service.GetUserResponseById(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UserResponseModel>>> CreateUserResponse([FromBody] UserResponseModel responseModel)
        {
            var response = await _service.CreateUserResponse(responseModel);
            return CreatedAtAction(nameof(GetUserResponseById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<UserResponseModel>>> UpdateUserResponse(Guid id, [FromBody] UserResponseModel responseModel)
        {
            if (id != responseModel.Id)
                return BadRequest("O ID da URL não bate com o do corpo da requisição.");

            var response = await _service.UpdateUserResponse(id, responseModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<UserResponseModel>>> DeleteUserResponse(Guid id)
        {
            var response = await _service.DeleteUserResponse(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }
    }
}
