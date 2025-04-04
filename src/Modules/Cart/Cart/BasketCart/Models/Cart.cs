using Shared.DDD;

namespace BasketCart.BasketCart.Models;

public class Cart : Aggregate<Guid>
{
public string UserName { get; private set; } = string.Empty;
private readonly List<CartItem> _cartItems = new();
public IReadOnlyList<CartItem> CartItems => _cartItems.AsReadOnly();
public decimal TotalPrice => _cartItems.Sum(x => x.Price * x.Quantity);

public static Cart Create(Guid id, string userName)
{
    ArgumentException.ThrowIfNullOrEmpty(userName);
    
    var cart = new Cart()
    {
        Id = id,
        UserName = userName
    };
    return cart;
}
public void AddItem(Guid productId, int quantity, string color, decimal price, string productName)
{
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
    ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

    var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == productId);

    if (existingItem != null)
    {
        existingItem.Quantity += quantity;
    }
    else
    {
        var newItem = new CartItem(Id, productId, quantity, color, price, productName);
        _cartItems.Add(newItem);
    }
}

public void RemoveItem(Guid productId)
{
    var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == productId);

    if (existingItem != null)
    {
        _cartItems.Remove(existingItem);
    }
}
}