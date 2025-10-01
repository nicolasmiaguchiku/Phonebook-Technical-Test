using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Input.Handlers.Commands;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PhonebookCommandController(IMediator mediator) : ControllerBase
    {

        [HttpPost("AddContact-Phonebook")]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand request, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new CreateContactCommand(request.AddContactRequest), cancellationToken);

            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateContactbyId")]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("DeleteContactById")]
        public async Task<IActionResult> DeleteContactById([FromQuery] string id)
        {
            var result = await mediator.Send(new DeleteContactCommand(id));
            return Ok(result);
        }
    }
}
