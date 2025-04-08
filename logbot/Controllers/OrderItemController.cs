using logbot.Models;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemInterface _service;

        public OrderItemController(IOrderItemInterface orderItemService)
        {
            _service = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderItemModel>>>> GetAllOrderItems()
        {
            return Ok(await _service.GetAllOrderItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderItemModel>>> GetOrderItemById(Guid id)
        {
            var response = await _service.GetOrderItemById(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<OrderItemModel>>> CreateOrderItem([FromBody] OrderItemModel item)
        {
            var response = await _service.CreateOrderItem(item);
            return CreatedAtAction(nameof(GetOrderItemById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderItemModel>>> UpdateOrderItem(Guid id, [FromBody] OrderItemModel updatedItem)
        {
            if (id != updatedItem.Id)
                return BadRequest("ID da URL não bate com o do corpo da requisição.");

            var response = await _service.UpdateOrderItem(id, updatedItem);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderItemModel>>> DeleteOrderItem(Guid id)
        {
            var response = await _service.DeleteOrderItem(id);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
