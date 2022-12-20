using FluentValidation;

namespace MovieInfo.InternalApi.Models;

public sealed class AddMovieBinding
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}

public sealed class CreateMovieBindingValidator : AbstractValidator<AddMovieBinding>
{
    public CreateMovieBindingValidator()
    {
        RuleFor(m => m.Title).NotEmpty();
    }
}
