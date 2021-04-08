using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.DataAccess.CQRS;
using AnimalsShelter.DataAccess.CQRS.Commands;
using AnimalsShelter.DataAccess.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalsShelter.ApplicationServices.API.Handlers
{
    public class AddAnimalHandler : IRequestHandler<AddAnimalRequest, AddAnimalResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddAnimalHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddAnimalResponse> Handle(AddAnimalRequest request, CancellationToken cancellationToken)
        {
            var animal = _mapper.Map<Animal>(request);
            var command = new AddAnimalCommand() { Parameter = animal };
            var animalFromDb = await _commandExecutor.Executor(command);
            return new AddAnimalResponse()
            {
                Data = _mapper.Map<Domain.Models.Animal>(animalFromDb)
            };
        }
    }
}
