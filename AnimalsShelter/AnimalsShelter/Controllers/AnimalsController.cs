using AnimalsShelter.ApplicationServices.API.Domain;
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
    public class AnimalsController : ApiControllerBase
    {
        private readonly IRepository<Animal> _animalRepository;

        public AnimalsController(IMediator mediator, IRepository<Animal> animalRepository, ILogger<AnimalsController> logger) : base(mediator)
        {
            _animalRepository = animalRepository;
            logger.LogInformation("We are in Animals");
        }

        [HttpGet]
        [Route("")]
        public Task<List<Animal>> GetAllAnimals()
        {
            return _animalRepository.GetAll();
        }

        [HttpGet]
        [Route("getByBreedId/{breedId}")]
        public Task<IActionResult> GetAnimalsByBreedId([FromRoute] int breedId)
        {
            var request = new GetAnimalsRequest()
            {
                BreedId = breedId
            };
            return this.HandleRequest<GetAnimalsRequest, GetAnimalsResponse>(request);
        }

        [HttpGet]
        [Route("getById/{animalId}")]
        public Task<IActionResult> GetAnimalById([FromRoute] int animalId)
        {
            var request = new GetAnimalByIdRequest()
            {
                AnimalId = animalId
            };
            return this.HandleRequest<GetAnimalByIdRequest, GetAnimalByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddAnimal([FromBody] AddAnimalRequest request)
        {
            return this.HandleRequest<AddAnimalRequest, AddAnimalResponse>(request);
        }

        [HttpPut]
        [Route("{animalId}")]
        public Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest request, int animalId)
        {
            request.Id = animalId;
            return this.HandleRequest<UpdateAnimalRequest, UpdateAnimalResponse>(request);
        }

        [HttpDelete]
        [Route("{animalId}")]
        public Task<IActionResult> RemoveAnimal([FromBody] RemoveAnimalRequest request)
        {
            return this.HandleRequest<RemoveAnimalRequest, RemoveAnimalResponse>(request);
        }
    }
}
