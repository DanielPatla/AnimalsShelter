using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Handlers
{
    public class GetAnimalsHandler : IRequestHandler<GetAnimalsRequest, GetAnimalsResponse>
    {
        private readonly IRepository<Animal> _animalRepository;

        public GetAnimalsHandler(IRepository<DataAccess.Entities.Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public Task<GetAnimalsResponse> Handle(GetAnimalsRequest request, CancellationToken cancellationToken)
        {
            var animals = _animalRepository.GetAll();
            var domainAnimals = animals.Select(x => new Domain.Models.Animal()
            {
                Name = x.Name,
                Age = x.Age,
                Sex = x.Sex,
                Breed = x.Breed
            });

            var response = new GetAnimalsResponse()
            {
                Data = domainAnimals.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
