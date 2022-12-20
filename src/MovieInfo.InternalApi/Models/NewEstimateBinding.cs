using FluentValidation;

namespace MovieInfo.InternalApi.Models;

public sealed class NewEstimateBinding
{
    public int Estimate { get; set; }
}

public sealed class NewEstimateBindingValidator : AbstractValidator<NewEstimateBinding>
{
    public NewEstimateBindingValidator()
    {
        RuleFor(r => r.Estimate)
            .NotNull()
            .GreaterThanOrEqualTo(1).WithMessage("Значение должно быть больше или равно 1")
            .LessThanOrEqualTo(5).WithMessage("Значение должно быть меньше или равно 5"); 
    }
}