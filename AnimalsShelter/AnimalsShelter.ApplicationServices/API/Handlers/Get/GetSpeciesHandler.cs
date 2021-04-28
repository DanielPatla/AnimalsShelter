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
    public class GetSpeciesHandler : IRequestHandler<GetSpeciesRequest, GetSpeciesResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetSpeciesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public Task<GetSpeciesResponse> Handle(GetSpeciesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSpeciesQuery();

            var species = _queryExecutor.Execute(query);
            var mappedSpecies = _mapper.Map<List<Domain.Models.Specie>>(species);
            var response = new GetSpeciesResponse()
            {
                Data = mappedSpecies
            };
            return Task.FromResult(response);
        }
    }
}
