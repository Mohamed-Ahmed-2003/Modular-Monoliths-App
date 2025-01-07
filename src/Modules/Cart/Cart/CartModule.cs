using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cart;

public static class CartModule
{
    public static IServiceCollection ConfigureCartModule(this IServiceCollection services,IConfiguration configuration)
    {
        return services;
    }
    public static IApplicationBuilder UseCartModule(this IApplicationBuilder app)
    {
        return app;
    }
}