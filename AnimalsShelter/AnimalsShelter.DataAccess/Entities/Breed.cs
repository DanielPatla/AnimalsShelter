using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    class Breed : EntityBase
    {
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }

        [ForeignKey("Specie")]
        public int SpiecieId { get; set; }
    }
}