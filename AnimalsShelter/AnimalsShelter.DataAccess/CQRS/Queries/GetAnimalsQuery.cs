﻿using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.CQRS.Queries
{
    public class GetAnimalsQuery : QueryBase<List<Animal>>
    {
        public int BreedId { get; set; }

        public override Task<List<Animal>> Execute(AnimalsShelterStorageContext context)
        {
            return context.Animals.Where(x => x.BreedId == this.BreedId).ToListAsync();
        }
    }
}
