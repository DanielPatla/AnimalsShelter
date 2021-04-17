using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.CQRS.Queries;
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
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetAnimalsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetAnimalsResponse> Handle(GetAnimalsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAnimalsQuery()
            {
                BreedId = request.BreedId
            };
            var animals = await _queryExecutor.Execute(query);
            var mappedAnimals = _mapper.Map<List<Domain.Models.Animal>>(animals);
            var response = new GetAnimalsResponse()
            {
                Data = mappedAnimals
            };
            return response;
        }
    }
}
