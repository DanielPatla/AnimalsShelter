using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain
{
    public class GetAnimalByIdRequest : IRequest<GetAnimalByIdResponse>
    {
        public int AnimalId { get; set; }
    }
}
