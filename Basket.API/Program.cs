using Basket.API.Data;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    }
);

builder.Services.AddMarten(
    otps =>
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string is missing");

        otps.Connection(connectionString);
        otps.Schema.For<ShoppingCart>().Identity(x => x.UserName);
    }
).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomerExceptionHandler>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
builder.Services.AddHealthChecks()
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!)
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();
app.MapCarter();

app.UseExceptionHandler(options => { });
app.MapHealthChecks("/health");
app.Run();