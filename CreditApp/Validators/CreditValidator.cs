using CreditApp.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Validators
{
    public class CreditValidator : AbstractValidator<Credit>
    {
        public CreditValidator()
        {
            RuleFor(x=>x.Amount).GreaterThan(0);
            RuleFor(x=>x.Term).GreaterThan(0);
        }
    }
}
