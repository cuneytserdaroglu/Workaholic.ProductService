using Microsoft.EntityFrameworkCore;
using Workaholic.ProductService.Domain;

namespace Workaholic.ProductService.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ProductDBContext _dbContext;

    public ProductRepository(ProductDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _dbContext.Set<Product>().Where(x => x.IsActive).ToListAsync();
    }

    public async Task Add(Product product)
    {
        await _dbContext.Product.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }
}