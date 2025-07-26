using Catalog.API.Product.Create;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddCarter(configurator: config => { config.WithModule<CreateProductEndpoint>(); });
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

app.Run();