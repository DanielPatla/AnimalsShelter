using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands
{
    public class RemoveAnimalCommand : CommandBase<Animal, Animal>
    {
        public override async Task<Animal> Execute(AnimalsShelterStorageContext context)
        {
            context.Animals.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
