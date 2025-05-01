namespace RedisCacheDemo.Caching;

public interface ICacheService
{
    Task<T> GetData<T>(string key);

    void SetData<T>(string key, T value, DateTimeOffset expirationTime);

    void RemoveData(string key);
}
