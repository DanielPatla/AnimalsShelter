using MediatR;

namespace AnimalsShelter.Controllers
{
    public class AddSpecieRequest : IRequest<AddSpecieResponse>
    {
        public string Name { get; set; }
    }
}