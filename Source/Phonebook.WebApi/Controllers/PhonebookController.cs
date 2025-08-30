using MediatR;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Application.Commands;
using Phonebook.Application.Queries.GetAllContacts;
using Phonebook.Domain.Entities;
using Phonebook.Shared.Results;


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

            return Ok(result);
        }


        [HttpGet("GetAllContact-Phonebook")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllContactsQuery());
            return Ok(result);
        }

    }
}
