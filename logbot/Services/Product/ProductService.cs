using logbot.Database;
using logbot.Models;
using Microsoft.EntityFrameworkCore;

namespace logbot.Services.ProductService
{
    public class ProductService : IProductInterface
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ProductModel>>> GetAllProducts()
        {
            var response = new ServiceResponse<List<ProductModel>>
            {
                Data = await _context.Products.Include(p => p.Company).ToListAsync(),
                Success = true
            };

            return response;
        }

        public async Task<ServiceResponse<ProductModel>> GetProductById(Guid id)
        {
            var response = new ServiceResponse<ProductModel>();
            var product = await _context.Products.Include(p => p.Company).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Produto não encontrado";
                return response;
            }

            response.Data = product;
            response.Success = true;
            return response;
        }

        public async Task<ServiceResponse<ProductModel>> CreateProduct(ProductModel product)
        {
            var response = new ServiceResponse<ProductModel>();

            var company = await _context.Companies.FindAsync(product.CompanyId);
            if (company == null)
            {
                response.Success = false;
                response.Message = "Empresa não encontrada";
                return response;
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            response.Data = product;
            response.Success = true;
            response.Message = "Produto criado com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<ProductModel>> UpdateProduct(Guid id, ProductModel updatedProduct)
        {
            var response = new ServiceResponse<ProductModel>();
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Produto não encontrado";
                return response;
            }

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Category = updatedProduct.Category;
            product.IsAvailable = updatedProduct.IsAvailable;
            product.UpdatedAt = DateTime.UtcNow;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            response.Data = product;
            response.Success = true;
            response.Message = "Produto atualizado com sucesso!";
            return response;
        }

        public async Task<ServiceResponse<ProductModel>> DeleteProduct(Guid id)
        {
            var response = new ServiceResponse<ProductModel>();
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                response.Success = false;
                response.Message = "Produto não encontrado";
                return response;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            response.Data = product;
            response.Success = true;
            response.Message = "Produto deletado com sucesso!";
            return response;
        }
    }
}
