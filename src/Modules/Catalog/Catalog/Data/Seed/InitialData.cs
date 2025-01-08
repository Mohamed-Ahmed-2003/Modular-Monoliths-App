using Catalog.Products.Models;

namespace Catalog.Data.Seed;

public class InitialData
{
    public static IEnumerable<Product> Products  => new List<Product>
    {
        Product.Create(
            name: "Wireless Mouse",
            price: 25.99m,
            description: "Ergonomic wireless mouse with adjustable DPI.",
            imageUrl: "wireless-mouse.jpg",
            category: ["Electronics", "Accessories"]
        ),
        Product.Create(
            name: "Gaming Keyboard",
            price: 89.99m,
            description: "Mechanical gaming keyboard with RGB lighting.",
            imageUrl: "gaming-keyboard.jpg",
            category: ["Electronics", "Gaming"]
        ),
        Product.Create(
            name: "Bluetooth Headphones",
            price: 119.99m,
            description: "Noise-cancelling over-ear headphones with Bluetooth 5.0.",
            imageUrl: "bluetooth-headphones.jpg",
            category: new List<string> { "Electronics", "Audio" }
        ),
        Product.Create(
            name: "Smartphone Stand",
            price: 15.49m,
            description: "Adjustable smartphone stand for desks and tables.",
            imageUrl: "smartphone-stand.jpg",
            category: ["Accessories", "Office"]
        ),
        Product.Create(
            name: "Portable Charger",
            price: 39.99m,
            description: "20,000mAh power bank with fast charging support.",
            imageUrl: "portable-charger.jpg",
            category: ["Electronics", "Mobile"]
        )
    };
}
