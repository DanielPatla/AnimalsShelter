using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain.Delete
{
    public class RemoveBreedRequest : IRequest<RemoveBreedResponse>
    {
        public int Id { get; set; }
    }
}
