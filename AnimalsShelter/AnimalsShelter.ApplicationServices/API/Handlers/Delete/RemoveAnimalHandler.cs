using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.ErrorHandling;
using AnimalsShelter.Controllers;
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
    public class RemoveAnimalHandler : IRequestHandler<RemoveAnimalRequest, RemoveAnimalResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public RemoveAnimalHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveAnimalResponse> Handle(RemoveAnimalRequest request, CancellationToken cancellationToken)
        {
            var animal = _mapper.Map<Animal>(request);
            var command = new RemoveAnimalCommand() { Parameter = animal };
            await _commandExecutor.Executor(command);

            if (animal == null)
            {
                return new RemoveAnimalResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            return new RemoveAnimalResponse()
            {
                Data = null
            };
        }
    }
}
