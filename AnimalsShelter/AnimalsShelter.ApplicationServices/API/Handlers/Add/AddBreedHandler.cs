using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess.CQRS;
using AnimalsShelter.DataAccess.CQRS.Commands;
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
    public class AddBreedHandler : IRequestHandler<AddBreedRequest, AddBreedResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddBreedHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddBreedResponse> Handle(AddBreedRequest request, CancellationToken cancellationToken)
        {
            var breed = _mapper.Map<Breed>(request);
            var command = new AddBreedCommand() { Parameter = breed };
            var breedFromDb = await _commandExecutor.Executor(command);
            return new AddBreedResponse()
            {
                Data = _mapper.Map<Domain.Models.Breed>(breedFromDb)
            };
        }
    }
}
