using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.ApplicationServices.API.ErrorHandling;
using AnimalsShelter.DataAccess.CQRS;
using AnimalsShelter.DataAccess.CQRS.Commands.Put;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Handlers.Put
{
    public class UpdateSpecieHandler : IRequestHandler<UpdateSpecieRequest, UpdateSpecieResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateSpecieHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateSpecieResponse> Handle(UpdateSpecieRequest request, CancellationToken cancellationToken)
        {
            var specie = _mapper.Map<Specie>(request);
            var command = new UpdateSpecieCommand() { Parameter = specie };
            var specieFromDb = await _commandExecutor.Executor(command);

            if (specie == null)
            {
                return new UpdateSpecieResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new UpdateSpecieResponse()
            {
                Data = _mapper.Map<Domain.Models.Specie>(specieFromDb)
            };
        }
    }
}
