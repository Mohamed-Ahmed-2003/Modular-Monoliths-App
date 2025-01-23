using Catalog.Events;
using Shared;
using Shared.DDD;

namespace  Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    public  string  Name { get; private set; }
    public string? Description { get; private set; }
    public string? ImageUrl { get; private set; }
    public List<string>? Category { get; private set; }
    public decimal Price { get; private set; }

    public static Product Create(Guid id, string name, List<string> category, string description, string imageUrl, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageUrl = imageUrl,
            Price = price
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }
    
    public void Update(string name, List<string> category, string description, string imageUrl, decimal price)
    {
         ArgumentException.ThrowIfNullOrEmpty(name);
         ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
         Name = name;
         Description = description;
         ImageUrl = imageUrl;
         Category = category;
         if (price == Price) return;
         Price = price;
         AddDomainEvent(new ProductPriceUpdatedEvent(this));
    }
}