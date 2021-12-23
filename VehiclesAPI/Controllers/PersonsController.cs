using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.PersonsServices.Commands.AddPerson;
using Application.Services.PersonsServices.Commands.DeletePerson;
using Application.Services.PersonsServices.Commands.UpdatePerson;
using Application.Services.PersonsServices.Queries.GetPersonById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VehiclesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonsController(IMediator mediator) => _mediator = mediator;       

        // GET: Personscontroller/Details/5
        [HttpGet("PersonDetails")]
        [ProducesResponseType(typeof(PersonModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> PersonDetails([FromQuery] int id)
        {
            var query = new PersonByIdQuery
            {
                Id = id
            };
            var person = await _mediator.Send(query);
            return Ok(person);
        }


        // GET: Personscontroller/Details/5
        [HttpGet("CheckPersonDetails")]
        [ProducesResponseType(typeof(PersonByNumberModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CheckPersonDetails([FromQuery] string personalNumber)
        {
            var query = new PersonByNumberQuery
            {
                PersonalNumber = personalNumber
            };
            var person = await _mediator.Send(query);
            return Ok(person);
        }


        // GET: Personscontroller/Create
        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson(AddPersonModel request)
        {
            var command = new AddPersonCommand
            {
                PersonNumber = request.PersonNumber,
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };
            var person = await _mediator.Send(command);
            return Ok(person);
        }


        // GET: Personscontroller/Update
        [HttpPut("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson(UpdatePersonModel request)
        {
            var command = new UpdatePersonCommand
            {
                Id = request.Id,
                PersonNumber = request.PersonNumber,
                Firstname = request.Firstname,
                Lastname = request.Lastname
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        // GET: Personscontroller/Delete
        [HttpDelete("DeletetePerson")]
        public async Task<IActionResult> DeletePerson([FromQuery]int id)
        {
            var command = new DeletePersonCommand
            {
                Id = id
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
    }
}
