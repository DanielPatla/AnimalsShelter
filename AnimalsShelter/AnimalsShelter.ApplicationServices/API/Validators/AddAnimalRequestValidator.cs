using AnimalsShelter.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Validators
{
    public class AddAnimalRequestValidator : AbstractValidator<AddAnimalRequest>
    {
        public AddAnimalRequestValidator()
        {
            this.RuleFor(x => x.Name).NotNull().Length(3, 35);
            this.RuleFor(x => x.Sex).NotNull();
            this.RuleFor(x => x.Age).NotNull().LessThan(DateTime.Now);
            this.RuleFor(x => x.BreedId).NotNull();
        }
    }
}
