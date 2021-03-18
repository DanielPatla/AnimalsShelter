using AnimalsShelter.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess
{
    class AnimalsStorageContext : DbContext
    {
        public AnimalsStorageContext(DbContextOptions<AnimalsStorageContext> opt) : base(opt)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Specie> Species { get; set; }
    }
}
