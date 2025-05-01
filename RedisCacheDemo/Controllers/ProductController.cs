
using RedisCacheDemo.Services;

namespace RedisCacheDemo.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController(ProductService productService) : ControllerBase
{
    private readonly ProductService _productService = productService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var products = await _productService.GetAll();

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
        return Ok(await _productService.AddNew(Product));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Product Product)
    {
        return Ok(await _productService.Update(id, Product));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _productService.Delete(id));
    }
}
