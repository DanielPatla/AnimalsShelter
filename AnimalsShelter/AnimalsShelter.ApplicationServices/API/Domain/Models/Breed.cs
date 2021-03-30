using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain.Models
{
    public class Breed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SpecieId { get; set; }
    }
}
