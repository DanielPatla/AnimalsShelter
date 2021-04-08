﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsShelter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddSpecie([FromBody] AddSpecieRequest request)
        {
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}