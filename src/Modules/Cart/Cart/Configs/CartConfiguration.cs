using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketCart.Configs;

public class CartConfiguration : IEntityTypeConfiguration<BasketCart.Models.Cart>
{
    public void Configure(EntityTypeBuilder<BasketCart.Models.Cart> builder)
    {
        builder.HasKey(e => e.Id);

        builder.HasIndex(e => e.UserName)
            .IsUnique();

        builder.Property(e => e.UserName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(s => s.CartItems)
            .WithOne()
            .HasForeignKey(si => si.CartId);
    }
}