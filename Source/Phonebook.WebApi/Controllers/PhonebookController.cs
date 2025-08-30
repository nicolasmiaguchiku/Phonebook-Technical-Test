using Microsoft.AspNetCore.Mvc;
using MediatR;
using Phonebook.Shared.Results;
using Phonebook.Domain.Entities;
using Phonebook.Application.Commands;


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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactCommand command)
        {
            ResultData<Contact> result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
