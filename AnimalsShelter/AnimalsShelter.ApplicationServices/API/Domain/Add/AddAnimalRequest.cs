using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain
{
    public class AddAnimalRequest : IRequest<AddAnimalResponse>
    {
        public string Name { get; set; }

        public int BreedId { get; set; }

        public short Age { get; set; }

        public bool Sex { get; set; }
    }
}
