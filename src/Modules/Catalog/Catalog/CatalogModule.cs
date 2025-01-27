using System.Reflection;
using Catalog.Data.Seed;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;
using Shared.Data;
using Shared.Data.Interceptors;
using Shared.Data.Seed;

namespace Catalog;

public static class CatalogModule
{
    public static IServiceCollection ConfigureCatalogModule(this IServiceCollection services,IConfiguration configuration)
    {
        // DI 
        services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            }
        );
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        // interceptors 
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>()
               .AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        #region DB connection
        var connectionString = configuration.GetConnectionString("DbConnection");
        services.AddDbContext<CatalogDbContext>((sp ,opt) =>
        {
            opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
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