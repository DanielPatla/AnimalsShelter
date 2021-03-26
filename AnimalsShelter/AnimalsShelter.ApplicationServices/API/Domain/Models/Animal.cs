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
        public string Name { get; set; }

        public Breed Breed { get; set; }

        public short Age { get; set; }

        public bool Sex { get; set; }
    }
}
