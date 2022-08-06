using FluentValidation;
using Technical.Challenge.Application.DTOs;

namespace Technical.Challenge.Application.Validators
{
    public class InputDTOValidator : AbstractValidator<InputDTO>
    {
        public InputDTOValidator()
        {
            RuleFor(x => x.Number)
                .GreaterThan(0).WithMessage("The 'Number' is inválid.");
        }
    }
}
