using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Basket.AddBasket;

public record StoreBasketRequest(ShoppingCart Cart);

public class AddBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async ([FromBody] StoreBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<AddBasketCommand>();
            var result  = await sender.Send(command);

            return Results.Ok(result);
        });
    }
}