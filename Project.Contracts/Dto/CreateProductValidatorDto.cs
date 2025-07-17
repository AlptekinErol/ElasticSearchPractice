using FluentValidation;

namespace Project.Contracts.Dto;

public class CreateProductValidatorDto : AbstractValidator<CreateProductRequestDto>
{
    public CreateProductValidatorDto()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Description).NotEmpty();
    }
}