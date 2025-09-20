using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Input.Handlers.Commands;
using Phonebook.Domain.Entities;
using Phonebook.Domain.Results;
using Phonebook.Application.Dtos;


namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPut("UpdateContactbyId/{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] UpdateContactDto dto, CancellationToken cancellationToken)
        {
            var command = new UpdateContactCommand(id, dto.Name, dto.Phone, dto.Email, dto.DateOfBirth, dto.Addresses);

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


        [HttpDelete("DeleteContactById/{id}")]
        public async Task<IActionResult> DeleContactById(string id)
        {
            var result = await mediator.Send(new DeleteContactCommand(id));
            return Ok(result);
        }
    }
}
