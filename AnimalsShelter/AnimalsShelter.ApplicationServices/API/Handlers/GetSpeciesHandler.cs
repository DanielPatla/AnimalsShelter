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
    public class GetSpeciesHandler : IRequestHandler<GetSpeciesRequest, GetSpeciesResponse>
    {
        private readonly IRepository<Specie> _specieRepository;
        private readonly IMapper _mapper;

        public GetSpeciesHandler(IRepository<Specie> specieRepository, IMapper mapper)
        {
            _specieRepository = specieRepository;
            _mapper = mapper;
        }

        public Task<GetSpeciesResponse> Handle(GetSpeciesRequest request, CancellationToken cancellationToken)
        {
            var species = _specieRepository.GetAll();
            var mappedSpecies = _mapper.Map<List<Domain.Models.Specie>>(species);
            var response = new GetSpeciesResponse()
            {
                Data = mappedSpecies
            };
            return Task.FromResult(response);
        }
    }
}
