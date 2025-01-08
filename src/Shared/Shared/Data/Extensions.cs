using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Seed;

namespace Shared.Data;

public static class Extensions
{
    public static  void UseMigration<TContext>(this IApplicationBuilder app) where TContext : DbContext
    {
         MigrateAsync<TContext>(app.ApplicationServices).GetAwaiter().GetResult();
         SeedDataAsync(app.ApplicationServices).GetAwaiter().GetResult();
    }

    private static async Task SeedDataAsync(IServiceProvider sp)
    {
        await using var serviceScope = sp.CreateAsyncScope();
        var seeders = serviceScope.ServiceProvider.GetServices<IDataSeeder>();
        foreach (var seeder in seeders)
        {
            await seeder.SeedDataAsync();
        }
    }

    private static  async Task MigrateAsync<TContext>(IServiceProvider sp) where TContext : DbContext
    {
        await using var scope =  sp.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }
    }
}