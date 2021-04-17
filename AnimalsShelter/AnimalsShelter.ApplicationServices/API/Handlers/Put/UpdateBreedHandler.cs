using AnimalsShelter.ApplicationServices.API.Domain.Put;
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
    public class UpdateBreedHandler : IRequestHandler<UpdateBreedRequest, UpdateBreedResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICommandExecutor _commandExecutor;

        public UpdateBreedHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            _mapper = mapper;
            _commandExecutor = commandExecutor;
        }

        public async Task<UpdateBreedResponse> Handle(UpdateBreedRequest request, CancellationToken cancellationToken)
        {
            var breed = _mapper.Map<Breed>(request);
            var command = new UpdateBreedCommand() { Parameter = breed };
            var breedFromDb = await _commandExecutor.Executor(command);
            return new UpdateBreedResponse()
            {
                Data = _mapper.Map<Domain.Models.Breed>(breedFromDb)
            };
        }
    }
}
