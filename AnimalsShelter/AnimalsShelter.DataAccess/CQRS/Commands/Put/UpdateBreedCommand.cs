using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands.Put
{
    public class UpdateBreedCommand : CommandBase<Breed, Breed>
    {
        public override async Task<Breed> Execute(AnimalsShelterStorageContext context)
        {
            context.Breeds.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
