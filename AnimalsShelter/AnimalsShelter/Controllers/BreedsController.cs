using AnimalsShelter.DataAccess;
using AnimalsShelter.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedsController : ControllerBase
    {
        private readonly IRepository<Breed> _breedRepository;

        public BreedsController(IRepository<Breed> breedRepository) =>
            _breedRepository = breedRepository;

        [HttpGet]
        [Route("")]
        public Task<List<Breed>> GetAllBreeds() =>
            _breedRepository.GetAll();

        [HttpGet]
        [Route("breedId")]
        public Task<Breed> GetBreedById(int breedId) =>
            _breedRepository.GetById(breedId);
    }
}
