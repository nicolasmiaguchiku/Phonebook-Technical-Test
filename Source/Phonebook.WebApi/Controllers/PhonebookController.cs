using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Commands;
using Phonebook.Application.Queries.GetAllContacts;
using Phonebook.Application.Queries.GetContactById;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;
using Phonebook.WebApi.Dtos;


namespace Phonebook.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhonebookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhonebookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            return Ok("Deu certo");
        }

        [HttpPost("AddContact-Phonebook")]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            ResultData<Contact> result = await _mediator.Send(command);

            if(result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

            
        }


        [HttpGet("GetAllContact-Phonebook")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContactsQuery());
            return Ok(result);
        }


        [HttpGet("GetContactById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery(id));

            if (!result.IsSuccess)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("DeleteContactById/{id}")]
        public async Task<IActionResult> DeleContactById(string id)
        {
            var result = await _mediator.Send(new DeleteContactCommand(id));
            return Ok(result);
        }

        [HttpPut("UpdateContactbyId{id}")]
        public async Task<IActionResult> UpdateContact(string id, [FromBody] UpdateContactDto dto)
        {
            var command = new UpdateContactCommand(id, dto.Name, dto.Phone, dto.Email, dto.DateOfBirth, dto.Addresses);

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
