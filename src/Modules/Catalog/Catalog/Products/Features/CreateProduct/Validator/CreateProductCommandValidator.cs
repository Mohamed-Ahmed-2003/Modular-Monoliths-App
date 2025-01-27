using Catalog.Products.Features.Handler.CreateProduct;

namespace Catalog.Products.Features.CreateProduct.Validator;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>

{
    public  CreateProductCommandValidator()
    {
        RuleFor(x => x.Product).NotNull();
        RuleFor(x => x.Product.Name).NotNull();
        RuleFor(x => x.Product.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.Product.Category).NotNull();
    }
}