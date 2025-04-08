using logbot.Models;
using logbot.Services.ConversationStepService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationStepController : ControllerBase
    {
        private readonly IConversationStepInterface _service;

        public ConversationStepController(IConversationStepInterface conversationStepService)
        {
            _service = conversationStepService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ConversationStepModel>>>> GetAllConversationSteps()
        {
            return Ok(await _service.GetAllConversationSteps());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationStepModel>>> GetConversationStepById(Guid id)
        {
            var response = await _service.GetConversationStepById(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ConversationStepModel>>> CreateConversationStep([FromBody] ConversationStepModel step)
        {
            var response = await _service.CreateConversationStep(step);
            return CreatedAtAction(nameof(GetConversationStepById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationStepModel>>> UpdateConversationStep(Guid id, [FromBody] ConversationStepModel step)
        {
            if (id != step.Id) return BadRequest("ID da URL não bate com o do corpo.");
            var response = await _service.UpdateConversationStep(id, step);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationStepModel>>> DeleteConversationStep(Guid id)
        {
            var response = await _service.DeleteConversationStep(id);
            if (response.Data == null) return NotFound(response);
            return Ok(response);
        }
    }
}
