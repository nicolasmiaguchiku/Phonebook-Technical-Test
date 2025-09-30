using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Input.Handlers.Queries;
using Phonebook.Application.Requests;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PhonebookQuerieController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllContact-Phonebook")]
        public async Task<IActionResult> GetAll([FromQuery] ContactRequest contactRequest, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllContactsQuery(contactRequest), cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetById([FromQuery] ContactRequest contactRequest, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetContactByIdQuery(contactRequest), cancellationToken);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        
    }
}
