using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAnimalsHandler(IRepository<DataAccess.Entities.Animal> animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<GetAnimalsResponse> Handle(GetAnimalsRequest request, CancellationToken cancellationToken)
        {
            var animals = await _animalRepository.GetAll();
            var mappedAnimals = _mapper.Map<List<Domain.Models.Animal>>(animals);
            var response = new GetAnimalsResponse()
            {
                Data = mappedAnimals
            };
            return response;
        }
    }
}
