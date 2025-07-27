var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMarten(
    otps => { otps.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!); }
).UseLightweightSessions();

var app = builder.Build();

app.MapCarter();
app.Run();