using logbot.Models;
using logbot.Services.ConversationService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationInterface _Service;

        public ConversationController(IConversationInterface conversationService)
        {
            _Service = conversationService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ConversationModel>>>> GetAllConversations()
        {
            var response = await _Service.GetAllConversations();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationModel>>> GetConversationById(Guid id)
        {
            var response = await _Service.GetConversationById(id);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ConversationModel>>> CreateConversation([FromBody] ConversationModel conversation)
        {
            var response = await _Service.CreateConversation(conversation);
            if (!response.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetConversationById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationModel>>> UpdateConversation(Guid id, [FromBody] ConversationModel conversation)
        {
            if (id != conversation.Id)
                return BadRequest("ID da URL não bate com o do corpo da requisição.");

            var response = await _Service.UpdateConversation(id, conversation);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ConversationModel>>> DeleteConversation(Guid id)
        {
            var response = await _Service.DeleteConversation(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
