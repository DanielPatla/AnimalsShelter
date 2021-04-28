using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Queries
{
    public class GetBreedsQuery : QueryBase<List<Breed>>
    {
        public override async Task<List<Breed>> Execute(AnimalsShelterStorageContext context)
        {
            return await context.Breeds.ToListAsync();
        }
    }
}
