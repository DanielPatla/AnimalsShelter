using AnimalsShelter.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Validators
{
    public class AddBreedRequestValidator : AbstractValidator<AddBreedRequest>
    {
        public AddBreedRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(1, 35);
            this.RuleFor(x => x.SpecieId).InclusiveBetween(1, 10);
        }
    }
}
