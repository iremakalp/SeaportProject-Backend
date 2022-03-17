using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ContainerValidator:AbstractValidator<Container>
    {
        public ContainerValidator()
        {
            RuleFor(c => c.TypeName).NotEmpty();
            RuleFor(c => c.Length).GreaterThan(0);
            RuleFor(c => c.Capacity).GreaterThan(0);
            RuleFor(c => c.CargoWeight).GreaterThan(0);
            RuleFor(c => c.Height).GreaterThan(0);
            RuleFor(c => c.Width).GreaterThan(0);
        }
    }
}