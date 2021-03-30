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
    public class SpeciesController : ControllerBase
    {
        private readonly IRepository<Specie> _specieRepository;

        public SpeciesController(IRepository<Specie> specieRepository) => 
            _specieRepository = specieRepository;

        [HttpGet]
        [Route("")]
        public Task<List<Specie>> GetAllSpecies() =>
            _specieRepository.GetAll();

        [HttpGet]
        [Route("specieId")]
        public Task<Specie> GetSpecieById(int specieId) => 
            _specieRepository.GetById(specieId);
    }
}
