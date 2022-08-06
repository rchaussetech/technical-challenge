using FluentValidation.Results;
using System;
using Technical.Challenge.Application.Validators;

namespace Technical.Challenge.Application.DTOs
{
    public class InputDTO
    {
        public int Number { get; set; }

        public bool IsValid(out string errorMessage)
        {
            InputDTOValidator validator = new();
            ValidationResult result = validator.Validate(this);
            errorMessage = result.ToString(Environment.NewLine);
            return result.IsValid;
        }
    }
}
