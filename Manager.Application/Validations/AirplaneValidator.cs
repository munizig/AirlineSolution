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
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.ModelId).NotEmpty();
            RuleFor(x => x.PassengersQuantity).NotEmpty().GreaterThan((short)0);
        }
    }
}
