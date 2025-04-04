using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketCart.Configs;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(oi => oi.ProductId).IsRequired();

        builder.Property(oi => oi.Quantity).IsRequired();

        builder.Property(oi => oi.Color);

        builder.Property(oi => oi.Price).IsRequired();

        builder.Property(oi => oi.ProductName).IsRequired();
    }
}