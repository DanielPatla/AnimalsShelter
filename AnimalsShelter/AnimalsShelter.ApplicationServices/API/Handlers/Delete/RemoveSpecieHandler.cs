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
    public class RemoveSpecieHandler : IRequestHandler<RemoveSpecieRequest, RemoveSpecieResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public RemoveSpecieHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<RemoveSpecieResponse> Handle(RemoveSpecieRequest request, CancellationToken cancellationToken)
        {
            var specie = _mapper.Map<Specie>(request);
            var command = new RemoveSpecieCommand() { Parameter = specie };
            await _commandExecutor.Executor(command);
            return new RemoveSpecieResponse()
            {
                Data = null
            };
        }
    }
}
