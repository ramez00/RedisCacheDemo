namespace RedisCacheDemo.Services;

public class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext _productService = dbContext;

    public async Task<int> AddNew(Product Product)
    {
        await _productService.Products.AddAsync(Product);
        await _productService.SaveChangesAsync();

        return Product.id;
    }

    public async Task<int> Delete(int id)
    {
        var Product = await _productService.Products.FindAsync(id);
        if (Product is null)
            return 0;

        _productService.Products.Remove(Product);
        await _productService.SaveChangesAsync();
        return 1;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _productService.Products.ToListAsync();
    }

    public Task<Product?> GetById(int id)
    {
        var Product = _productService.Products.FirstOrDefaultAsync(c => c.id == id);

        if (Product is null)
            return Task.FromResult<Product?>(null);

        return Product;
    }

    public async Task<int> Update(int id, Product Product)
    {
        var existingProduct = await _productService.Products.FirstOrDefaultAsync(c => c.id == id);

        if (existingProduct is null)
            return 0;

        existingProduct.Name = Product.Name;
        existingProduct.Description = Product.Description;
        existingProduct.stock = Product.stock;

        _productService.Products.Update(existingProduct);
        await _productService.SaveChangesAsync();

        return 1;
    }
}
