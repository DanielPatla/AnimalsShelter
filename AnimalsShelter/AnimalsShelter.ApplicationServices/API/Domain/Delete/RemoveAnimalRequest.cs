using MediatR;

namespace AnimalsShelter.Controllers
{
    public class RemoveAnimalRequest : IRequest<RemoveAnimalResponse>
    {
        public int Id { get; set; }
    }
}