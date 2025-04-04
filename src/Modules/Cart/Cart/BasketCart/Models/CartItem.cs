using Shared.DDD;

namespace BasketCart.BasketCart.Models;

public class CartItem :Entity<Guid>
{
    public Guid CartId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; internal set; }
    public string Color { get; private set; } = string.Empty;
    
    
    public decimal Price { get; private set; }
    public string ProductName { get; private set; } = string.Empty;

    public
        CartItem(Guid cartId, Guid productId, int quantity, string color,decimal price, string productName){
        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
        Color = color;
        ProductName  = productName;
        Price = price;
    }

}