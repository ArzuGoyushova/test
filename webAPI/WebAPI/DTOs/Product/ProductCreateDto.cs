using FluentValidation;

namespace WebAPI.DTOs.Product
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("bosh qoyma")
                .MaximumLength(20).WithMessage("20den kichik");
            RuleFor(p => p.SalePrice)
                .NotNull().WithMessage("bosh ola bilmez")
                .GreaterThanOrEqualTo(0).WithMessage("0-dan boyuk olmalidi");
            RuleFor(p => p.CostPrice)
               .NotNull().WithMessage("bosh ola bilmez")
               .GreaterThanOrEqualTo(0).WithMessage("0-dan boyuk olmalidi");
            RuleFor(p => p).Custom((p, context) =>
            {
                if (p.CostPrice > p.SalePrice)
                {
                    context.AddFailure("CostPrice", "CostPrice SalePricedan boyuk ola bilmez");
                }
            });

        }
            
    }
}
