using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    public class Breed : EntityBase
    {
        [ForeignKey("Specie")]
        public int SpecieId { get; set; }

        [MaxLength(35)]
        public string Name { get; set; }

        public List<Animal> Animals { get; set; }
    }
}