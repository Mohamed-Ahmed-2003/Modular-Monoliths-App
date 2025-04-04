using BasketCart.Data;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Behaviors;
using Shared.Data;
using Shared.Data.Interceptors;

namespace BasketCart;

public static class CartModule
{
    public static IServiceCollection ConfigureCartModule(this IServiceCollection services,IConfiguration configuration)
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
        services.AddDbContext<CartDbContext>((sp ,opt) =>
        {
            opt.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            opt.UseNpgsql(connectionString);
        });
        #endregion
        
        // services.AddScoped<IDataSeeder, CatalogDataSeeder>();
        return services;
    }

    public static IApplicationBuilder UseCartModule(this IApplicationBuilder app)
    {
        app.UseMigration<CartDbContext>();
        return app;
    }
}