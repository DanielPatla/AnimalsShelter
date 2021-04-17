using AnimalsShelter.ApplicationServices.API.Domain;
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
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Animal> _animalRepository;

        public AnimalsController(IMediator mediator, IRepository<Animal> animalRepository)
        {
            _mediator = mediator;
            _animalRepository = animalRepository;
        }

        [HttpGet]
        [Route("")]
        public Task<List<Animal>> GetAllAnimals() =>
            _animalRepository.GetAll();

        [HttpGet]
        [Route("{breedId")]
        public async Task<IActionResult> GetAnimalsByBreedId([FromQuery] GetAnimalsRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{animalId}")]
        public async Task<IActionResult> GetAnimalById([FromRoute] int animalId)
        {
            var request = new GetAnimalByIdRequest()
            {
                AnimalId = animalId
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddAnimal([FromBody] AddAnimalRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{animalId}")]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest request, int animalId)
        {
            request.Id = animalId;
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{animalId}")]
        public async Task<IActionResult> RemoveAnimal([FromBody] RemoveAnimalRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
