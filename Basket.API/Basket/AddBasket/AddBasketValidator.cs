
namespace Basket.API.Basket.AddBasket;

public class AddBasketValidator : AbstractValidator<AddBasketCommand>
{

    public AddBasketValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Giỏ hàng không được trống");
        RuleFor(x => x.Cart.UserName).NotNull().WithMessage("Yêu cầu người dùng");
        
    }
}