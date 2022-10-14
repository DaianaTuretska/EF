using BLL.DTO.Requests;
using FluentValidation;

namespace BLL.Validation.Requests
{
    public class MovieRequestValidator : AbstractValidator<MovieRequest>
    {
        public MovieRequestValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty()
                .WithMessage(product => $"{nameof(product.Id)} can't be empty.");

            RuleFor(product => product.Name)
                .NotEmpty()
                .WithMessage(product => $"{nameof(product.Name)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(product => $"{nameof(product.Name)} should be less than 50 characters");

            RuleFor(product => product.Price)
                .NotEmpty()
                .WithMessage(product => $"{nameof(product.Price)} can't be empty.")
                .GreaterThan(0)
                .WithMessage(product => $"{nameof(product.Price)} should be more than 0.");

            RuleFor(product => product.SeanceTime)
                .NotEmpty()
                .WithMessage(product => $"{nameof(product.SeanceTime)} can't be empty.")
                .GreaterThanOrEqualTo(0)
                .WithMessage(product => $"{nameof(product.SeanceTime)} should be more or equeal to 0.");

            RuleFor(product => product.CinemaId)
                .NotEmpty()
                .WithMessage(product => $"{nameof(product.CinemaId)} can't be empty.");

        }
    }
}
