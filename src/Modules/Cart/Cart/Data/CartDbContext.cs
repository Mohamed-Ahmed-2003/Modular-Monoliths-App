namespace BasketCart.Data;
public class CartDbContext(DbContextOptions<CartDbContext> options) : DbContext(options)
{
    public DbSet<BasketCart.Models.Cart> ShoppingCarts => Set<BasketCart.Models.Cart>();
    public DbSet<CartItem> ShoppingCartItems => Set<CartItem>();

    protected override void OnModelCreating(ModelBuilder builder)
    {        
        builder.HasDefaultSchema("cart");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

}