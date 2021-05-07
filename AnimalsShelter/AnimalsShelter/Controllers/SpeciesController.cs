using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.Domain.Delete;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeciesController : ApiControllerBase
    {
        public SpeciesController(IMediator mediator, ILogger<SpeciesController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Species");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllSpecies([FromQuery] GetSpeciesRequest request)
        {
            return this.HandleRequest<GetSpeciesRequest, GetSpeciesResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddSpecie([FromBody] AddSpecieRequest request)
        {
            return this.HandleRequest<AddSpecieRequest, AddSpecieResponse>(request);
        }

        [HttpPut]
        [Route("{specieId}")]
        public Task<IActionResult> UpdateSpecie([FromBody] UpdateSpecieRequest request, int specieId)
        {
            request.Id = specieId;
            return this.HandleRequest<UpdateSpecieRequest, UpdateSpecieResponse>(request);
        }

        [HttpDelete]
        [Route("{specieId}")]
        public Task<IActionResult> RemoveSpecie([FromBody] RemoveSpecieRequest request)
        {
            return this.HandleRequest<RemoveSpecieRequest, RemoveSpecieResponse>(request);
        }
    }
}
