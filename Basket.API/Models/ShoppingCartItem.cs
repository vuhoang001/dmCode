using System.ComponentModel.DataAnnotations;

namespace Basket.API.Models;

public class ShoppingCartItem
{
    [MaxLength(255)] public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
    public Guid ProductId { get; set; }
}