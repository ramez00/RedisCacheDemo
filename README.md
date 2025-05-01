📦 Distributed Caching in .NET 8 with Redis

This project demonstrates how to implement Distributed Caching using Redis in a .NET 8 Web API. Caching is a powerful tool to boost performance, reduce response times, and minimize database hits.

🚀 Features

🔄 Distributed Cache Integration using Redis

💾 Product Data Caching

⚡ Fast retrieval of data from Redis

📉 Reduced Database Load

🧰 Tech Stack

Backend: .NET 8 Web API

Cache Store: Redis (via Docker)

Library: StackExchange.Redis

Tooling: Visual Studio, Docker, Redis CLI

🧪 Example: Product Cache

🗂️ Redis Hash Structure

Key: ProductRedisproducts

Field: data

Value: (JSON Serialized Array of Products)

[
  {"id":1, "Name":"Mouse", "Description":"Mouse", "stock":50},
  {"id":2, "Name":"Screen", "Description":"Screen", "stock":250},
  {"id":3, "Name":"Keyboard", "Description":"Keyboard", "stock":650}
]

📥 Storing Data in Redis (from .NET)

await _distributedCache.SetStringAsync("ProductRedisproducts:data", jsonData);

📤 Fetching Data from Redis

var cachedData = await _distributedCache.GetStringAsync("ProductRedisproducts:data");

🧪 CLI Example

Using redis-cli, run:

HGETALL ProductRedisproducts

Sample output:

1) "data"
2) "[{\"id\":1,\"Name\":\"Mouse\", ...]"

Other fields like absexp and sldexp are system-managed expiration settings.

🐳 Docker Setup

Run Redis container:

docker run --name redis -d -p 6379:6379 redis

Access CLI:

docker exec -it redis redis-cli

🧠 Summary

Redis helps boost performance and scalability by caching frequently accessed data in memory. Integrating it with .NET 8 is simple and effective.

Feel free to fork, clone, and explore!

📧 For any queries or contributions, feel free to open an issue or contact the maintainer.

Happy Caching! 🚀

![DataFrom Redis Cache](https://github.com/user-attachments/assets/b2fdbdef-e707-44b9-bb11-306f00ade290)
