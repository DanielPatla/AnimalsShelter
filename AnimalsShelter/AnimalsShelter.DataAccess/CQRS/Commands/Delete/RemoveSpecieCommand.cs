using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Commands.Delete
{
    public class RemoveSpecieCommand : CommandBase<Specie, Specie>
    {
        public override async Task<Specie> Execute(AnimalsShelterStorageContext context)
        {
            context.Species.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
