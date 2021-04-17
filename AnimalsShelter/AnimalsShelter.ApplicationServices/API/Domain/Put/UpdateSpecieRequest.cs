using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Domain.Put
{
    public class UpdateSpecieRequest : IRequest<UpdateSpecieResponse>
    {
        public int Id;

        public string Name { get; set; }
    }
}
