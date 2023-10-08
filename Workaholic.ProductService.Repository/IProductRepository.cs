using Workaholic.ProductService.Domain;

namespace Workaholic.ProductService.Repository;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task Add(Product product);
}