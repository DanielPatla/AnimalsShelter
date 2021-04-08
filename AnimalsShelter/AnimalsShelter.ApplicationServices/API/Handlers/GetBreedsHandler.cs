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
    public class GetBreedsHandler : IRequestHandler<GetBreedsRequest, GetBreedsResponse>
    {
        private readonly IRepository<Breed> _breedRepository;
        private readonly IMapper _mapper;

        public GetBreedsHandler(IRepository<Breed> breedRepository, IMapper mapper)
        {
            _breedRepository = breedRepository;
            _mapper = mapper;
        }

        public Task<GetBreedsResponse> Handle(GetBreedsRequest request, CancellationToken cancellationToken)
        {
            var breeds = _breedRepository.GetAll();
            var mappedBreeds = _mapper.Map<List<Domain.Models.Breed>>(breeds);
            var response = new GetBreedsResponse()
            {
                Data = mappedBreeds
            };
            return Task.FromResult(response);
        }
    }
}
