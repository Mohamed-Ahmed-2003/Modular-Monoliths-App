using Shared.Data.Seed;

namespace Catalog.Data.Seed;

public class CatalogDataSeeder(CatalogDbContext ctx) : IDataSeeder
{
    public async Task SeedDataAsync()
    {
        if (!await ctx.Products.AnyAsync())
        {
            await ctx.Products.AddRangeAsync(InitialData.Products);
            await ctx.SaveChangesAsync();
        }
    }
}