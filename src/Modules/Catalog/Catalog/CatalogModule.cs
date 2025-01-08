using Catalog.Data.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;
using Shared.Data.Seed;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection ConfigureCatalogModule(this IServiceCollection services,IConfiguration configuration)
    {
        #region DB connection
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<CatalogDbContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });
        #endregion
        
        services.AddScoped<IDataSeeder, CatalogDataSeeder>();
        return services;
    }

    public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
    {
        app.UseMigration<CatalogDbContext>();
        return app;
    }
    
}