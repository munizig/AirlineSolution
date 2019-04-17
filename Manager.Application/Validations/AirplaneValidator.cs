using FluentValidation;
using Manager.Domain.Contracts;
using Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Application.Validations
{
    public class AirplaneValidator : AbstractValidator<AirplaneContractRequest>
    {
        public AirplaneValidator()
        {
            RuleFor(x => x.Code).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model).NotEmpty().MinimumLength(2);
            RuleFor(x => x.PassengersQuantity).NotEmpty().GreaterThan((short)0);
        }
    }
}
