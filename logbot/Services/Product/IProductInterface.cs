using logbot.Models;

public interface IProductInterface
{
    Task<ServiceResponse<List<ProductModel>>> GetAllProducts();
    Task<ServiceResponse<ProductModel>> GetProductById(Guid id);
    Task<ServiceResponse<ProductModel>> CreateProduct(ProductModel product);
    Task<ServiceResponse<ProductModel>> UpdateProduct(Guid id, ProductModel updatedProduct);
    Task<ServiceResponse<ProductModel>> DeleteProduct(Guid id);
}
