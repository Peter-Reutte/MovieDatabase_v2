using FluentValidation;

namespace MovieInfo.InternalApi.Models;

public sealed class CreateMovieBinding
{
    public string Title { get; set; } = null!;
}

public sealed class CreateMovieBindingValidator : AbstractValidator<CreateMovieBinding>
{
    public CreateMovieBindingValidator()
    {
        RuleFor(m => m.Title).NotEmpty();
    }
}
