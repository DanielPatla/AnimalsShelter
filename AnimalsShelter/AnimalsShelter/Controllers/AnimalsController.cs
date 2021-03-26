using AnimalsShelter.ApplicationServices.API.Domain;
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

        public AnimalsController(IMediator mediator) =>
            _mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllAnimals([FromQuery] GetAnimalsRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }

    }
}
