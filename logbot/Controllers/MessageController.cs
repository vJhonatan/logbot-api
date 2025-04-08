using logbot.Models;
using logbot.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageInterface _service;

        public MessageController(IMessageInterface messageService)
        {
            _service = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MessageModel>>>> GetAllMessages()
        {
            var response = await _service.GetAllMessages();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<MessageModel>>> GetMessageById(Guid id)
        {
            var response = await _service.GetMessageById(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<MessageModel>>> CreateMessage([FromBody] MessageModel message)
        {
            var response = await _service.CreateMessage(message);
            if (!response.Success) return BadRequest(response);

            return CreatedAtAction(nameof(GetMessageById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<MessageModel>>> UpdateMessage(Guid id, [FromBody] MessageModel updatedMessage)
        {
            if (id != updatedMessage.Id) return BadRequest("ID da URL não bate com o corpo da requisição");

            var response = await _service.UpdateMessage(id, updatedMessage);
            if (!response.Success) return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<MessageModel>>> DeleteMessage(Guid id)
        {
            var response = await _service.DeleteMessage(id);
            if (!response.Success) return NotFound(response);

            return Ok(response);
        }
    }
}
