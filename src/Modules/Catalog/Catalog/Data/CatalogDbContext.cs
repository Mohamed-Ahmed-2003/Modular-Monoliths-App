using Catalog.Products.Models;

namespace Catalog.Data;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{   
    public DbSet<Product> Products => Set<Product>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Catalog);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}