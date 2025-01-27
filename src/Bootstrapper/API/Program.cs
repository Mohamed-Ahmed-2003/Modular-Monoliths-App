using Carter;
using Catalog.Products.Features.CreateProduct;
using FluentValidation.AspNetCore;
using Shared.Exceptions.Handler;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Register Modules

builder.Services.AddCarterModules(typeof(CatalogModule).Assembly);
builder.Services
    .ConfigureCatalogModule(builder.Configuration)
    .ConfigureCartModule(builder.Configuration)
    .ConfigureOrderingModule(builder.Configuration);

#endregion

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(options => { });

app.UseCatalogModule()
    .UseOrderingModule()
    .UseCartModule();
app.Run();