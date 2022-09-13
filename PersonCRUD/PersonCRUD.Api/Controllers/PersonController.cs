using MediatR;
using Microsoft.AspNetCore.Mvc;
using PersonCRUD.Application.DataAccess;
using PersonCRUD.Application.PersonInfo.Commands;
using PersonCRUD.Application.PersonInfo.Queries;

namespace PersonCRUD.Api.Controllers
{
    [ApiController]
    [Route("api/person")]
    [Produces("application/json")]
    public class PersonController : Controller
    {
        private readonly IMediator mediator;
        public PersonController(IMediator mediator) => this.mediator = mediator;

        //Fetch All

        [HttpGet]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllPerson()
        {
            var result = await mediator.Send(new GetAllPerson());
            return result == null ? NotFound() : Ok(result);
        }

        //By ID

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var result = await mediator.Send(new GetPersonById() { Id = id });
            return result == null ? NotFound() : Ok(result);
        }

        //Create Data
        [HttpPost]
        [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertData(CreatePersonCommand request)
        {
            var result = await mediator.Send(request);

            return result == null ? BadRequest() : Ok(result);
        }

        //Update data
        [HttpPut]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateData(UpdatePersonCommand request)
        {
            //request.Id = id;

            var result = await mediator.Send(request);

            return result == null ? BadRequest() : Ok(result);

        }

        //Delete data
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateData([FromRoute] int id, DeletePersonCommand request)
        {
            request.Id = id;

            var result = await mediator.Send(request);

            return result == null ? BadRequest() : Ok(result);

        }

    }
}
