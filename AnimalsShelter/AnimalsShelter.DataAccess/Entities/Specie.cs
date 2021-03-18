using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    class Specie : EntityBase
    {
        public string Name { get; set; }

        public List<Breed> Breeds { get; set; }
    }
}
