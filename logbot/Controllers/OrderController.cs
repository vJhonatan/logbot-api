using logbot.Models;
using logbot.Services.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderInterface _service;

        public OrderController(IOrderInterface orderService)
        {
            _service = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<OrderModel>>>> GetAllOrders()
        {
            return Ok(await _service.GetAllOrders());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> GetOrderById(Guid id)
        {
            var response = await _service.GetOrderById(id);
            if (response.Data == null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> CreateOrder([FromBody] OrderModel order)
        {
            var response = await _service.CreateOrder(order);
            if (!response.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetOrderById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> UpdateOrder(Guid id, [FromBody] OrderModel updatedOrder)
        {
            if (id != updatedOrder.Id)
                return BadRequest("ID da URL não bate com o corpo da requisição");

            return Ok(await _service.UpdateOrder(id, updatedOrder));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<OrderModel>>> DeleteOrder(Guid id)
        {
            var response = await _service.DeleteOrder(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
