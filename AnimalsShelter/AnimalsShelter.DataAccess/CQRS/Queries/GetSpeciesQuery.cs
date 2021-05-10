using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Queries
{
    public class GetSpeciesQuery : QueryBase<List<Specie>>
    {
        public override async Task<List<Specie>> Execute(AnimalsShelterStorageContext context)
        {
            return await context.Species
                .ToListAsync();
        }
    }
}
