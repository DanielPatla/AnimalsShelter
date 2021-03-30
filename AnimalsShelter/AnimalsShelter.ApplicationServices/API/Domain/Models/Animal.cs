using AnimalsShelter.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BreedId { get; set; }

        public short Age { get; set; }

        public bool Sex { get; set; }
    }
}
