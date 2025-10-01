using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Domain.Dtos.Requests;
using Phonebook.Application.Input.Handlers.Queries;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PhonebookQuerieController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAllContact-Phonebook")]
        public async Task<IActionResult> GetAll([FromQuery] GetContactRequest contactRequest, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetAllContactsQuery(contactRequest), cancellationToken);
            return Ok(result);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetById([FromQuery] GetContactRequest contactRequest, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetContactByIdQuery(contactRequest), cancellationToken);

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }
    }
}
