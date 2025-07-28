using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssembly(typeof(Program).Assembly);
        config.AddOpenBehavior(typeof(ValidationBehavior<,>));
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

var app = builder.Build();

app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
        if (exception is null) return;

        var problemDetails = new ProblemDetails
        {
            Title  = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.StackTrace,
        };

        var logger = context.RequestServices.GetService<ILogger<Program>>();
        if (logger != null) logger.LogError(exception, exception.Message);

        context.Response.StatusCode  = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.MapCarter();
app.UseExceptionHandler();
app.Run();