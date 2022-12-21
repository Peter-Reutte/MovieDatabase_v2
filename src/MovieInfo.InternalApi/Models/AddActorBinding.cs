using FluentValidation;

namespace MovieInfo.InternalApi.Models;

public sealed class AddActorBinding
{
    public string Name { get; set; } = null!;
}

public sealed class AddActorBindingValidator : AbstractValidator<AddActorBinding>
{
    public AddActorBindingValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
    }
}