
namespace RedisCacheDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(ApplicationDbContext dbContext) : ControllerBase
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    [HttpGet("products")]
    public IEnumerable<Product> Get()
    {
        var data = _dbContext.Products.ToList();
        return data;
    }
    [HttpGet("product")]
    public Product? Get(int id)
    {
        var data = _dbContext.Products.Where(x => x.id == id).FirstOrDefault();
        return data;
    }
    [HttpPost("addproduct")]
    public async Task<Product> Post(Product value)
    {
        var obj = await _dbContext.Products.AddAsync(value);
        _dbContext.SaveChanges();
        return obj.Entity;
    }
    [HttpPut("updateproduct")]
    public void Put(Product product)
    {
        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();
    }
    [HttpDelete("deleteproduct")]
    public void Delete(int Id)
    {
        var filteredData = _dbContext.Products.Where(x => x.id == Id).FirstOrDefault();
        _dbContext.Remove(filteredData);
        _dbContext.SaveChanges();
    }
}
