namespace RedisCacheDemo.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAll();
    Task<int> AddNew(Product Product);
    Task<Product?> GetById(int id);
    Task<int> Update(int id, Product Product);
    Task<int> Delete(int id);
}
