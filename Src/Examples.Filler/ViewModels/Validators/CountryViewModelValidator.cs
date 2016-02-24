using System.Linq;
using FluentValidation;

namespace Examples.Filler.ViewModels.Validators
{
    public class CountryViewModelValidator : AbstractValidator<CountryViewModel>
    {
        public CountryViewModelValidator() {
            RuleFor(m => m.CountryId)
                .Must((m, p) => m.Countries.Any(c => c.Key == p))
                .WithMessage("Please specify valid Country");
        }
    }
}