using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Model).MinimumLength(3);
            RuleFor(c => c.Model).MaximumLength(50);
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan(1900);
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).LessThanOrEqualTo(9999);
        }
    }
}