﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleAPI.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Controllers
{
    [SwaggerTag("This is an example controller generated by ASP.NET Core 3.1")]
    [ApiController]
    // you can remove api from the url below
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
            OperationId = "GetSamples",
            Summary = "Get all samples",
            Description = "returns all samples"
        )]
        public ActionResult<IEnumerable<Sample>> GetSamples()
        {
            var rng = new Random();
            List<Sample> samples = new List<Sample>();
            samples.AddRange(Enumerable.Range(1, 5).Select(index => new Sample
            {
                CustomerId = 1,
                FirstName = "FirstName",
                LastName = "LastName"
            })
            .ToArray());

            return samples;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            OperationId = "GetSample",
            Summary = "Get specific sample",
            Description = "return a sample"
        )]
        public ActionResult<Sample> GetSample(int id)
        {
            if (id == 5)
            {
                return NotFound();
            }

            var sample = new Sample
            {
                CustomerId = id,
                FirstName = "FirstName",
                LastName = "LastName"
            };

            return sample;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            OperationId = "PostSample",
            Summary = "Create a sample",
            Description = "Create a new Sample"
        )]
        public ActionResult PostSample([FromBody] Sample sample)
        {

            if (sample.CustomerId == 5)
            {
                return BadRequest();
            }

            if (sample.CustomerId == 6)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            OperationId = "PutSample",
            Summary = "Update a sample",
            Description = "Update an existing Sample"
        )]
        public ActionResult PutSample(int id, [FromBody] Sample sample)
        {
            if (id == 5)
            {
                return BadRequest();
            }

            if (id == 6)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
            OperationId = "DeleteSample",
            Summary = "Delete a sample",
            Description = "Delete an existing Sample"
        )]
        public ActionResult DeleteSample(int id)
        {
            if (id == 5)
            {
                return BadRequest();
            }

            if (id == 6)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
