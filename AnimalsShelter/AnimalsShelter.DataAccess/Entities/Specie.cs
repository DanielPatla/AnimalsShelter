using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    public class Specie : EntityBase
    {
        [MaxLength(20)]
        public string Name { get; set; }

        public List<Breed> Animals { get; set; }
    }
}
