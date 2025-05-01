using System.ComponentModel.DataAnnotations;

namespace RedisCacheDemo.Models;

public class Product
{
    public int id { get; set; }
    
    [MaxLength(20)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string Description { get; set; } = string.Empty;
    public int stock { get; set; }
}
