using logbot.Models;
using logbot.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace logbot.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductInterface _service;

        public ProductController(IProductInterface productService)
        {
            _service = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductModel>>>> GetAllProducts()
        {
            var response = await _service.GetAllProducts();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> GetProductById(Guid id)
        {
            var response = await _service.GetProductById(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> CreateProduct([FromBody] ProductModel product)
        {
            var response = await _service.CreateProduct(product);
            if (!response.Success)
                return BadRequest(response);

            return CreatedAtAction(nameof(GetProductById), new { id = response.Data.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> UpdateProduct(Guid id, [FromBody] ProductModel product)
        {
            if (id != product.Id)
                return BadRequest("O ID da URL não bate com o do corpo da requisição.");

            var response = await _service.UpdateProduct(id, product);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<ProductModel>>> DeleteProduct(Guid id)
        {
            var response = await _service.DeleteProduct(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }
    }
}
