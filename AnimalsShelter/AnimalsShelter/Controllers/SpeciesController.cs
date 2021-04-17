using AnimalsShelter.ApplicationServices.API.Domain.Delete;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeciesController : ControllerBase
    {
        private readonly IRepository<Specie> _specieRepository;
        private readonly IMediator _mediator;

        public SpeciesController(IRepository<Specie> specieRepository, IMediator mediator)
        {
            _specieRepository = specieRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public Task<List<Specie>> GetAllSpecies() =>
            _specieRepository.GetAll();

        [HttpGet]
        [Route("{specieId}")]
        public Task<Specie> GetSpecieById(int specieId) => 
            _specieRepository.GetById(specieId);

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSpecie([FromBody] AddSpecieRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{specieId}")]
        public async Task<IActionResult> UpdateSpecie([FromBody] UpdateSpecieRequest request, int specieId)
        {
            request.Id = specieId;
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{specieId}")]
        public async Task<IActionResult> RemoveSpecie([FromBody] RemoveSpecieRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
