namespace Basket.API.Basket.DeleteBasket;

public class DeleteBasketValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketValidator()
    {
        RuleFor(x => x.Username).NotEmpty().NotNull().WithMessage("Yêu cầu người dùng");
    }
}