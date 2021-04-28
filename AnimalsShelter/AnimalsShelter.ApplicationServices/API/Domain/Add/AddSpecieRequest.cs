using MediatR;

namespace AnimalsShelter.ApplicationServices.API.Domain
{
    public class AddSpecieRequest : IRequest<AddSpecieResponse>
    {
        public string Name { get; set; }
    }
}