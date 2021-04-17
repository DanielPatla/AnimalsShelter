using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.CQRS;
using AnimalsShelter.DataAccess.CQRS.Commands;
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
    public class UpdateAnimalHandler : IRequestHandler<UpdateAnimalRequest, UpdateAnimalResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateAnimalHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateAnimalResponse> Handle(UpdateAnimalRequest request, CancellationToken cancellationToken)
        {
            var animal = _mapper.Map<Animal>(request);
            var command = new UpdateAnimalCommand() { Parameter = animal };
            var animalFromDb = await _commandExecutor.Executor(command);
            return new UpdateAnimalResponse()
            {
                Data = _mapper.Map<Domain.Models.Animal>(animalFromDb)
            };
        }
    }
}
