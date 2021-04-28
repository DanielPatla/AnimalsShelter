using AnimalsShelter.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Validators
{
    public class AddSpecieRequestValidator : AbstractValidator<AddSpecieRequest>
    {
        public AddSpecieRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 35);
        }
    }
}
