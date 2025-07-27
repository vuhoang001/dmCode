using Catalog.API.Product.Create;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddCarter(configurator: config => { config.WithModule<CreateProductEndpoint>(); });
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(
    otps => { otps.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!); }
).UseLightweightSessions();
app.Run();