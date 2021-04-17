using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Queries
{
    public class GetAnimalQuery : QueryBase<Animal>
    {
        public int Id { get; set; }

        public override async Task<Animal> Execute(AnimalsShelterStorageContext context)
        {
            return await context.Animals.FirstOrDefaultAsync(x => x.Id == this.Id);
        }
    }
}
