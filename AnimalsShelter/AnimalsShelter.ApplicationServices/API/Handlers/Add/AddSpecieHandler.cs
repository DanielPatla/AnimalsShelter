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
    public class AddSpecieHandler : IRequestHandler<AddSpecieRequest, AddSpecieResponse>
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IMapper _mapper;

        public AddSpecieHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<AddSpecieResponse> Handle(AddSpecieRequest request, CancellationToken cancellationToken)
        {
            var specie = _mapper.Map<Specie>(request);
            var command = new AddSpecieCommand() { Parameter = specie };
            var specieFromDb = await _commandExecutor.Executor(command);
            return new AddSpecieResponse()
            {
                Data = _mapper.Map<Domain.Models.Specie>(specieFromDb)
            };
        }
    }
}
