using MediatR;
using Microsoft.AspNetCore.Mvc;
using BitirmeProjesiBackend.Application.CQRS.Commands;
using BitirmeProjesiBackend.Application.CQRS.Queries;

namespace BitirmeProjesiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var result = await _mediator.Send(new GetEventListQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetEventByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveEvent(int id)
        {
            await _mediator.Send(new RemoveEventCommand(id));
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            await _mediator.Send(command);
            return Created("", command);
        }
    }
}
