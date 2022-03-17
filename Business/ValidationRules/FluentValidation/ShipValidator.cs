using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ShipValidator:AbstractValidator<Ship>
    {
        public ShipValidator()
        {
            RuleFor(s => s.ShipName).NotEmpty();
            RuleFor(s => s.Length).GreaterThan(0);
            RuleFor(s => s.Breadth).GreaterThan(0);
            RuleFor(s => s.DTW).GreaterThan(0);
            RuleFor(s => s.GRT).GreaterThan(0);
            RuleFor(s => s.ImoNo).NotEmpty();
            RuleFor(s => s.RegistrationNumber).NotEmpty();
        }
    }
}