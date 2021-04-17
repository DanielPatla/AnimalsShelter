using AnimalsShelter.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalsShelter.DataAccess.Entities;
using MediatR;
using AnimalsShelter.ApplicationServices.API.Domain;
using AnimalsShelter.ApplicationServices.API.Domain.Put;
using AnimalsShelter.ApplicationServices.API.Domain.Delete;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedsController : ControllerBase
    {
        private readonly IRepository<Breed> _breedRepository;
        private readonly IMediator _mediator;

        public BreedsController(IRepository<Breed> breedRepository, IMediator mediator)
        {
            _breedRepository = breedRepository;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public Task<List<Breed>> GetAllBreeds() =>
            _breedRepository.GetAll();

        [HttpGet]
        [Route("breedId")]
        public Task<Breed> GetBreedById(int breedId) =>
            _breedRepository.GetById(breedId);

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBreed([FromBody] AddBreedRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("{breedId}")]
        public async Task<IActionResult> UpdateBreed([FromBody] UpdateBreedRequest request, int breedId)
        {
            request.Id = breedId;
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{breedId}")]
        public async Task<IActionResult> RemoveBreed([FromBody] RemoveBreedRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
