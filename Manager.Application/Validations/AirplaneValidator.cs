using FluentValidation;
using Manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Application.Validations
{
    public class AirplaneValidator : AbstractValidator<Airplane>
    {
        public AirplaneValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.PassengersQuantity).NotEmpty().GreaterThan((short)0);
        }
    }
}
