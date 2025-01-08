using Catalog.Products.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared;

namespace Catalog.Data.Configuration;

public class ProductConfig :IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(p=>p.Id);
        builder.Property(p=>p.Name).HasMaxLength(50).IsRequired();
        builder.Property(p=>p.Description).HasMaxLength(200);
        builder.Property(p=>p.ImageUrl).HasMaxLength(50);
        builder.Property(p=>p.Price).IsRequired();
    }
}