using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain
{
    public class AddBreedRequest : IRequest<AddBreedResponse>
    {
        public string Name { get; set; }

        public int SpecieId { get; set; }
    }
}
