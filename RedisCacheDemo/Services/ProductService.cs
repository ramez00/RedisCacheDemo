namespace RedisCacheDemo.Services;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<int> AddNew(Product Product)
    {
        await _dbContext.Products.AddAsync(Product);
        await _dbContext.SaveChangesAsync();

        return Product.id;
    }

    public async Task<int> Delete(int id)
    {
        var Product = await _dbContext.Products.FindAsync(id);
        if (Product is null)
            return 0;

        _dbContext.Products.Remove(Product);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public Task<Product?> GetById(int id)
    {
        var Product = _dbContext.Products.FirstOrDefaultAsync(c => c.id == id);

        if (Product is null)
            return Task.FromResult<Product?>(null);

        return Product;
    }

    public async Task<int> Update(int id, Product Product)
    {
        var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(c => c.id == id);

        if (existingProduct is null)
            return 0;

        existingProduct.Name = Product.Name;
        existingProduct.Description = Product.Description;
        existingProduct.stock = Product.stock;

        _dbContext.Products.Update(existingProduct);
        await _dbContext.SaveChangesAsync();

        return 1;
    }
}
