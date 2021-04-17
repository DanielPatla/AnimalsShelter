using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands
{
    public class UpdateAnimalCommand : CommandBase<Animal, Animal>
    {
        public override async Task<Animal> Execute(AnimalsShelterStorageContext context)
        {
            context.Animals.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
