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
    public class GetBreedsHandler : IRequestHandler<GetBreedsRequest, GetBreedsResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetBreedsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetBreedsResponse> Handle(GetBreedsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetBreedsQuery();
            var breeds = await _queryExecutor.Execute(query);

            if (breeds == null)
            {
                return new GetBreedsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedBreeds = _mapper.Map<List<Domain.Models.Breed>>(breeds);
            return new GetBreedsResponse()
            {
                Data = mappedBreeds
            };
        }
    }
}
