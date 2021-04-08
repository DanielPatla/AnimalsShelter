using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands
{
    public class AddBreedCommand : CommandBase<Breed, Breed>
    {
        public override async Task<Breed> Execute(AnimalsShelterStorageContext context)
        {
            await context.Breeds.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
