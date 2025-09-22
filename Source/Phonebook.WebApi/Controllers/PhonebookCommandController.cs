using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;

namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class PhonebookCommandController(IMediator mediator) : ControllerBase
    {

        [HttpPost("AddContact-Phonebook")]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command, CancellationToken cancellationToken)
        {
            ResultData<Contact> result = await mediator.Send(command, cancellationToken);

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
