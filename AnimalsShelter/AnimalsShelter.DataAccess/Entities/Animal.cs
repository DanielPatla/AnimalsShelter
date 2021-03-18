using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.DataAccess.Entities
{
    class Animal : EntityBase
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public short Age { get; set; }

        public bool Sex { get; set; }
    }
}
