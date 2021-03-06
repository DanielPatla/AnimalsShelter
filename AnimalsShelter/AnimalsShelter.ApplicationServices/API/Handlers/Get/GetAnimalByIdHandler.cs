﻿using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.ErrorHandling;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.CQRS.Queries;
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
    public class GetAnimalByIdHandler : IRequestHandler<GetAnimalByIdRequest, GetAnimalByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQueryExecutor _queryExecutor;

        public GetAnimalByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            _mapper = mapper;
            _queryExecutor = queryExecutor;
        }

        public async Task<GetAnimalByIdResponse> Handle(GetAnimalByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetAnimalQuery()
            {
                Id = request.AnimalId
            };
            var animal = await _queryExecutor.Execute(query);

            if(animal == null)
            {
                return new GetAnimalByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedAnimal = _mapper.Map<Domain.Models.Animal>(animal);
            return new GetAnimalByIdResponse()
            {
                Data = mappedAnimal
            };
        }
    }
}
