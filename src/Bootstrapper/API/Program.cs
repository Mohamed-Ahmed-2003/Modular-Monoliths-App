var builder = WebApplication.CreateBuilder(args);

#region Register Modules

builder.Services
    .ConfigureCatalogModule(builder.Configuration)
    .ConfigureCartModule(builder.Configuration)
    .ConfigureOrderingModule(builder.Configuration);

#endregion

var app = builder.Build();
app.UseCatalogModule()
    .UseOrderingModule()
    .UseCartModule();
app.Run();