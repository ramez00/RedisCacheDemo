
using RedisCacheDemo.Services;

namespace RedisCacheDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService,ICacheService cacheService) : ControllerBase
{
    private readonly IProductService _productService = productService;
    private readonly ICacheService _cacheService = cacheService;

    private readonly string _cacheKey = "products";

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cacheProducts = await _cacheService.GetData<IEnumerable<Product>>(_cacheKey);

        if (cacheProducts is not null)
            return Ok(cacheProducts);

        var products = await _productService.GetAll();

        var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

        _cacheService.SetData(_cacheKey, products,expirationTime);


        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _productService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] Product Product)
    {
        _cacheService.RemoveData(_cacheKey);
        return Ok(await _productService.AddNew(Product));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product Product)
    {
        _cacheService.RemoveData(_cacheKey);
        return Ok(await _productService.Update(id, Product));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        _cacheService.RemoveData(_cacheKey);
        return Ok(await _productService.Delete(id));
    }
}
