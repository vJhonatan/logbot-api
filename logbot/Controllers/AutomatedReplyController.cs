using logbot.Models;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomatedReplyController : ControllerBase
    {
        private readonly IAutomatedReplyInterface _service;

        public AutomatedReplyController(IAutomatedReplyInterface replyService)
        {
            _service = replyService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<AutomatedReplyModel>>>> GetAllReplies()
        {
            return Ok(await _service.GetAllReplies());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<AutomatedReplyModel>>> GetReplyById(Guid id)
        {
            var response = await _service.GetReplyById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<AutomatedReplyModel>>> CreateReply([FromBody] AutomatedReplyModel reply)
        {
            var response = await _service.CreateReply(reply);
            return CreatedAtAction(nameof(GetReplyById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<AutomatedReplyModel>>> UpdateReply(Guid id, [FromBody] AutomatedReplyModel reply)
        {
            if (id != reply.Id)
                return BadRequest("O ID da URL não bate com o corpo da requisição.");

            var response = await _service.UpdateReply(id, reply);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<AutomatedReplyModel>>> DeleteReply(Guid id)
        {
            var response = await _service.DeleteReply(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
