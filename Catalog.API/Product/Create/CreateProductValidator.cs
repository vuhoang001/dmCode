namespace Catalog.API.Product.Create;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Giá tiền phải lớn hơn 0");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Yêu cầu nhập tên");
        RuleFor(x => x.Description);
    }
}