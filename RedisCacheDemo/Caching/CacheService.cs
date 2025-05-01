
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RedisCacheDemo.Caching;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    private readonly IDistributedCache _distributedCache = distributedCache;

    public async Task<T> GetData<T>(string key)
    {
        var data = await _distributedCache.GetStringAsync(key);
        
        if (string.IsNullOrEmpty(data))
            return default!;

        return JsonSerializer.Deserialize<T>(data)!;
    }

    public async void RemoveData(string key)
    {
        await _distributedCache.RemoveAsync(key);
    }

    public async void SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        DistributedCacheEntryOptions options = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = expirationTime,
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };

        TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(value), options);
    }
}
