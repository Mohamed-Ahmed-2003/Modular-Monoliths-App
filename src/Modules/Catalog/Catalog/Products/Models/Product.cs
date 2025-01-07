using Catalog.Events;
using Shared;

namespace  Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    public  string  Name { get; private set; }
    public string? Description { get; private set; }
    public string? ImageUrl { get; private set; }
    public List<string>? Category { get; private set; }
    public decimal Price { get; private set; }

    public static Product Create(string name,decimal price, string? description = null, string? imageUrl = null,
        List<string>? category = null)
    {
         ArgumentException.ThrowIfNullOrEmpty(name);
         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
         var product = new Product { Name = name, Description = description, ImageUrl = imageUrl, Price = price, Category = category };
         product.AddDomainEvent (new ProductCreatedEvent(product));
         return product;
    }  
    
    public  void Update (string name,decimal price, string? description = null, string? imageUrl = null,
        List<string>? category = null)
    {
         ArgumentException.ThrowIfNullOrEmpty(name);
         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
         Name = name;
         Description = description;
         ImageUrl = imageUrl;
         Category = category;
         if (price != Price)
         {
             Price = price;
             AddDomainEvent(new ProductPriceUpdatedEvent(this));
         }
    }
}