using AnimalsShelter.ApplicationServices.API.Domain.Delete;
using AnimalsShelter.DataAccess.CQRS;
using AnimalsShelter.DataAccess.CQRS.Commands.Delete;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Handlers.Delete
{
    public class RemoveBreedHandler : IRequestHandler<RemoveBreedRequest, RemoveBreedResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public RemoveBreedHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveBreedResponse> Handle(RemoveBreedRequest request, CancellationToken cancellationToken)
        {
            var breed = _mapper.Map<Breed>(request);
            var command = new RemoveBreedCommand() { Parameter = breed };
            await _commandExecutor.Executor(command);
            return new RemoveBreedResponse()
            {
                Data = null
            };
        }
    }
}
