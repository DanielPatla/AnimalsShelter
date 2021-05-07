using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.ErrorHandling;
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

        public async Task<GetSpeciesResponse> Handle(GetSpeciesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetSpeciesQuery();
            var species = await _queryExecutor.Execute(query);

            if(species == null)
            {
                return new GetSpeciesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedSpecies = _mapper.Map<List<Domain.Models.Specie>>(species);
            return new GetSpeciesResponse()
            {
                Data = mappedSpecies
            };
        }
    }
}
