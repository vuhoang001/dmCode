var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    }
);
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<CustomerExceptionHandler>();
builder.Services.AddMarten(
    otps =>
    {
        var connectionString = builder.Configuration.GetConnectionString("Database");
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException("Connection string is missing");

        otps.Connection(connectionString);
    }
).UseLightweightSessions();

builder.Services.AddHealthChecks();

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitData>();
}


var app = builder.Build();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health");

app.MapCarter();
app.Run();