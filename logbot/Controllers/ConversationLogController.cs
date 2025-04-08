using logbot.Models;
using logbot.Services.ConversationLogService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationLogController : ControllerBase
    {
        private readonly IConversationLogInterface _service;

        public ConversationLogController(IConversationLogInterface conversationLogService)
        {
            _service = conversationLogService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ConversationLogModel>>>> GetAllLogs()
        {
            return Ok(await _service.GetAllLogs());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationLogModel>>> GetLogById(Guid id)
        {
            var response = await _service.GetLogById(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ConversationLogModel>>> CreateLog([FromBody] ConversationLogModel log)
        {
            var response = await _service.CreateLog(log);
            return CreatedAtAction(nameof(GetLogById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationLogModel>>> UpdateLog(Guid id, [FromBody] ConversationLogModel log)
        {
            if (id != log.Id)
                return BadRequest("O ID da URL não bate com o ID do corpo da requisição.");

            var response = await _service.UpdateLog(id, log);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationLogModel>>> DeleteLog(Guid id)
        {
            var response = await _service.DeleteLog(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }
    }
}
