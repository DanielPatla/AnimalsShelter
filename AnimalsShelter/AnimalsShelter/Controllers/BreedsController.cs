using AnimalsShelter.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsShelter.DataAccess.Entities;
using MediatR;
using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.ApplicationServices.API.Domain.Delete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedsController : ApiControllerBase
    {
        public BreedsController(IMediator mediator, ILogger<BreedsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Breeds");
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllBreeds([FromQuery] GetBreedsRequest request)
        {
            return this.HandleRequest<GetBreedsRequest, GetBreedsResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddBreed([FromBody] AddBreedRequest request)
        {
            return this.HandleRequest<AddBreedRequest, AddBreedResponse>(request);
        }

        [HttpPut]
        [Route("{breedId}")]
        public Task<IActionResult> UpdateBreed([FromBody] UpdateBreedRequest request, int breedId)
        {
            request.Id = breedId;
            return this.HandleRequest<UpdateBreedRequest, UpdateBreedResponse>(request);
        }

        [HttpDelete]
        [Route("{breedId}")]
        public Task<IActionResult> RemoveBreed([FromBody] RemoveBreedRequest request)
        {
            return this.HandleRequest<RemoveBreedRequest, RemoveBreedResponse>(request);
        }
    }
}
