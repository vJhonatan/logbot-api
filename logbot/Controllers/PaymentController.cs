using logbot.Models;
using logbot.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentInterface _service;

        public PaymentController(IPaymentInterface paymentService)
        {
            _service = paymentService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<PaymentModel>>>> GetAllPayments()
        {
            return Ok(await _service.GetAllPayments());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<PaymentModel>>> GetPaymentById(Guid id)
        {
            var response = await _service.GetPaymentById(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<PaymentModel>>> CreatePayment([FromBody] PaymentModel payment)
        {
            var response = await _service.CreatePayment(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<PaymentModel>>> UpdatePayment(Guid id, [FromBody] PaymentModel updatedPayment)
        {
            if (id != updatedPayment.Id) return BadRequest("O ID da URL não bate com o do corpo da requisição");
            return Ok(await _service.UpdatePayment(id, updatedPayment));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<PaymentModel>>> DeletePayment(Guid id)
        {
            var response = await _service.DeletePayment(id);
            if (!response.Success) return NotFound(response);
            return Ok(response);
        }
    }
}
