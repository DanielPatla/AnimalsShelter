using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands
{
    public class AddSpecieCommand : CommandBase<Specie, Specie>
    {
        public override async Task<Specie> Execute(AnimalsShelterStorageContext context)
        {
            await context.Species.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
