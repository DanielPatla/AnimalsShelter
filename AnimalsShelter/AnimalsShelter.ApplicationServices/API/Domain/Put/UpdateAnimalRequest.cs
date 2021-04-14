using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain
{
    public class UpdateAnimalRequest : IRequest<UpdateAnimalResponse>
    {
        public int Id;

        public string Name { get; set; }

        public bool Sex { get; set; }

        public short Age { get; set; }

        public int BreedId { get; set; }
    }
}
