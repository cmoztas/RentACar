using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();
            RuleFor(r => r.CarId).GreaterThan(0);
            RuleFor(r => r.CustomerId).NotEmpty();
            RuleFor(r => r.CustomerId).GreaterThan(0);
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).GreaterThan(new DateTime(1900 - 01 - 01));
            RuleFor(r => r.RentDate).LessThanOrEqualTo(DateTime.Now);
            RuleFor(r => r.ReturnDate).GreaterThan(new DateTime(1900 - 01 - 01));
            RuleFor(r => r.ReturnDate).LessThanOrEqualTo(DateTime.Now);
        }
    }
}