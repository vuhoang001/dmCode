using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.API.Models;

public class ShoppingCart
{
    [MaxLength(255)] public string UserName { get; set; } = null!;
    public List<ShoppingCartItem> Items { get; set; } = [];

    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart()
    {
    }

    public ShoppingCart(string username)
    {
        UserName = username;
    }
}