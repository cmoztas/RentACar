using FluentValidation;
using System.Drawing;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(3);
            RuleFor(c => c.Name).MaximumLength(15);
        }
    }
}