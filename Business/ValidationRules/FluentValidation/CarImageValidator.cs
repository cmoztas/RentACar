using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(ci => ci.CarId).NotEmpty();
            RuleFor(ci => ci.CarId).GreaterThan(0);
            RuleFor(ci => ci.Date).NotEmpty();
            RuleFor(ci => ci.ImagePath).NotEmpty();
            RuleFor(ci => ci.ImagePath).MinimumLength(7);
        }
    }
}